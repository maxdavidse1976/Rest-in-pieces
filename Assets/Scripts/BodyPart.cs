using UnityEngine;

public class BodyPart : PickUpAble
{
    [SerializeField] Grave.BodyPartColor _bodyPartColor;
    [SerializeField] int _scoreValue;
    
    public int GetScoreValue()
    {
        return _scoreValue;
    }
    public Grave.BodyPartColor GetBodyPartColor()
    {
        return _bodyPartColor;
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
