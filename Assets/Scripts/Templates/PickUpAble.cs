using UnityEngine;

public class PickUpAble : MonoBehaviour
{
    [SerializeField] protected GameObject pickupUI;
    public virtual void PickUp(Transform parent, Vector3 pickupPosition)
    {
        transform.SetParent(parent);
        transform.position = pickupPosition;
    }

    public virtual void Drop()
    {
        transform.SetParent(null);
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
