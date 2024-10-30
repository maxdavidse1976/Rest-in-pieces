using UnityEngine;

public partial class Grave : MonoBehaviour
{
    [SerializeField] int _bodyParts = 0;
    [SerializeField] BodyPartColor _bodyPartColor;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BodyPart bodyPart))
        {
           HandleBodyPartCollision(bodyPart);
        }
    }

    void HandleBodyPartCollision(BodyPart bodyPart)
    {
        if (bodyPart.GetBodyPartColor() == _bodyPartColor)
        {
            CollectBodyPart(bodyPart);
            return;
        }

        DisplayWrongBodyPartMessage();
    }

    void DisplayWrongBodyPartMessage()
    {

    }

    void CollectBodyPart(BodyPart bodyPart)
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
