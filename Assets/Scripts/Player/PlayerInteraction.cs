using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] BodyPart _currentPart = null;
    [SerializeField] PlayerCharacter _player;

    private void DropCurrentBone()
    {
        _currentPart = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_currentPart && collision.TryGetComponent(out BodyPart bone))
        {
            bone.ShowPickUpUI();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && !_currentPart && collision.TryGetComponent(out BodyPart bone))
        {
            _currentPart = bone;
            _currentPart.OnItemDrop += DropCurrentBone;
            _currentPart.PickUp(_player, transform, transform.position);
            _currentPart.HidePickupUI();
        }

        if (Input.GetKeyDown(KeyCode.E) && _currentPart && collision.CompareTag("Grave"))
        {
            _currentPart.AttemptDrop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BodyPart bone))
        {
            if (!_currentPart) bone.HidePickupUI();

            if (_currentPart == bone)
            {
                _currentPart.OnItemDrop -= DropCurrentBone;
            }
        }

    }
}