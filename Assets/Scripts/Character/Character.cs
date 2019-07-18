using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform bodyTop;
    public int inventorySize = 10;

    protected Inventory inventory;
    protected EquipmentItem rightHand;
    protected EffectsController effects;

    private void Start()
    {
        effects = FindObjectOfType<EffectsController>();
        inventory = new Inventory(inventorySize);
    }

    public bool CanPick(InventoryItem item)
    {
        if (item.rightHand && rightHand != null)
            return false;
        return true;
    }

    public virtual void Freeze(bool freeze) {}

    public virtual void Pick(InventoryItem item)
    {
        Freeze(false);
        if (item.wearable != null)
            ReplaceInHand(item);
        else
            inventory.Add(item);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    private void ReplaceInHand(InventoryItem item)
    {
        EquipmentItem equip = Instantiate(item.wearable, bodyTop).GetComponent<EquipmentItem>();

        if (rightHand != null)
        {
            rightHand.OnHit -= OnWeaponHit;
            rightHand.Drop();
            Destroy(rightHand.gameObject);
        }
        equip.OnHit += OnWeaponHit;
        rightHand = equip;
    }

    private void OnWeaponHit(Collision collision)
    {
        EffectsController.EffectType effectType = EffectsController.EffectType.Default;
        if (collision.gameObject.tag == "Wood")
        {
            effectType = EffectsController.EffectType.Wood;
        }
        effects.SpawnParticles(collision.contacts[0].point, effectType);
    }
}
