using UnityEngine;

public class Character : MonoBehaviour
{
    public MovementControls movement;

    protected EquipmentItem rightHand;
    protected EquipmentItem leftHand;

    public bool CanPick(InventoryItem item)
    {
        if (item.leftHand && leftHand != null)
            return false;
        if (item.rightHand && rightHand != null)
            return false;
        return true;
    }

    public void Freeze()
    {
        movement.enabled = false;
    }

    public void Unfreeze()
    {
        movement.enabled = true;
    }

    public void Pick(InventoryItem item)
    {
        Unfreeze();
        if (item.wearable != null)
        {
            rightHand = Instantiate(item.wearable, transform).GetComponent<EquipmentItem>();
        }
    }
}
