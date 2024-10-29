using System;
using JetBrains.Annotations;
using UnityEngine;

public class PickUpAble : MonoBehaviour
{
    [SerializeField] protected GameObject pickupUI;
    [CanBeNull] private PlayerCharacter currentItemHolder;
    public event Action OnItemDrop;
    public event Action OnItemDropFailed;

    public PlayerCharacter GetCurrentItemHolder() => currentItemHolder;

    protected virtual void Awake()
    {
        OnItemDrop += () => currentItemHolder = null;
    }

    public virtual void PickUp(PlayerCharacter player,Transform parent, Vector3 pickupPosition)
    {
        currentItemHolder = player;
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
        OnItemDrop?.Invoke();
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
