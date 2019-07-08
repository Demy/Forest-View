using UnityEngine;

public class Character : MonoBehaviour
{
    public MovementControls movement;

    protected EquipmentItem rightHand;
    protected EquipmentItem leftHand;

    protected EffectsController effects;

    private void Start()
    {
        effects = FindObjectOfType<EffectsController>();
    }

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

    public virtual void Pick(InventoryItem item)
    {
        Unfreeze();
        if (item.wearable != null)
        {
            ReplaceInRightHand(item);
        }

        if (item.rightHand)
        {
            rightHand.OnHit += OnWeaponHit;
        }
        if (item.leftHand)
        {
            leftHand.OnHit += OnWeaponHit;
        }
    }

    private void ReplaceInRightHand(InventoryItem item)
    {
        EquipmentItem equip = Instantiate(item.wearable, transform).GetComponent<EquipmentItem>();

        if (rightHand != null)
        {
            rightHand.OnHit -= OnWeaponHit;
            rightHand.Drop();
            Destroy(rightHand.gameObject);
        }
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
