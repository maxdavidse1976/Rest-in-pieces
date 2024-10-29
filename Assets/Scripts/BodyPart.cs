using UnityEngine;

public class BodyPart : PickUpAble
{
    private Grave.BodyPartColor bodyPartColor;
    [SerializeField] private int scoreValue;
    public int GetScoreValue()
    {
        return scoreValue;
    }
    public Grave.BodyPartColor GetBodyPartColor()
    {
        return bodyPartColor;
    }

    public void DestroyBodyPart()
    {
        Drop();
        Destroy(gameObject);
    }
    protected override bool AreDropCircumstancesValid()
    {
        return true;
    }
}
