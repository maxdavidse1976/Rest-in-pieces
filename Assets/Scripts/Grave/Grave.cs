using UnityEngine;

public partial class Grave : MonoBehaviour
{
    [SerializeField] int _bodyParts = 0;
    [SerializeField] BodyPartColor _bodyPartColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check if the player is carrying a bodypart of the correct color
        //if that is the case, collect the bodypart and remove it from the player
        //if it isn't, do nothing or display a message that this is the wrong color bodypart
    }
}
