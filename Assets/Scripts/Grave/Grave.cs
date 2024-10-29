using UnityEngine;

public partial class Grave : MonoBehaviour
{
    [SerializeField] int _bodyParts = 0;
    [SerializeField] BodyPartColor _bodyPartColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BodyPart bodyPart))
        {
           HandleBodyPartCollision(bodyPart);
        }
    }

    private void HandleBodyPartCollision(BodyPart bodyPart)
    {
        if (bodyPart.GetBodyPartColor() == _bodyPartColor)
        {
            CollectBodyPart(bodyPart);
            return;
        }

        DisplayWrongBodyPartMessage();
    }

    private void DisplayWrongBodyPartMessage()
    {

    }

    private void CollectBodyPart(BodyPart bodyPart)
    {
        PlayerCharacter owningPlayer = bodyPart.GetCurrentItemHolder();
        if (owningPlayer)
        {
            owningPlayer.AddScore(bodyPart.GetScoreValue());
        }
        _bodyParts++;
        bodyPart.DestroyBodyPart();
    }
}
