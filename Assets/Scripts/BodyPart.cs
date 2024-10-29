using UnityEngine;

public class BodyPart : PickUpAble
{
    protected override bool AreDropCircumstancesValid()
    {
        return true;
    }
}
