using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    public Animator itemAnimator;
    public float singleUseTime;

    private float cooldown = 0;

    public void Use()
    {
        if (cooldown <= 0)
        {
            if (itemAnimator != null)
                itemAnimator.SetTrigger("Use");
            cooldown = singleUseTime;
        }
    }

    private void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }
}
