using System;
using UnityEngine;

public class PickUpAble : MonoBehaviour
{
    [SerializeField] protected GameObject pickupUI;
    public event Action OnItemDropSuccess;
    public event Action OnItemDropFailed;
    public virtual void PickUp(Transform parent, Vector3 pickupPosition)
    {
        transform.SetParent(parent);
        transform.position = pickupPosition;
    }

    public virtual void AttemptDrop()
    {
        if (AreDropCircumstancesValid())
        {
            Drop();
            return;
        }

        HandleFailedDropAttempt();
    }
    protected virtual void Drop()
    {
        transform.SetParent(null);
        OnItemDropSuccess?.Invoke();
    }

    protected virtual bool AreDropCircumstancesValid()
    {
        return true;
    }

    protected virtual void HandleFailedDropAttempt()
    {
        OnItemDropFailed?.Invoke();
    }

    public virtual void ShowPickUpUI()
    {
        pickupUI.SetActive(true);
    }

    public virtual void HidePickupUI()
    {
        pickupUI.SetActive(false);
    }
}
