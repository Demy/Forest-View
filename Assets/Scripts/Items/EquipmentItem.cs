using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    public delegate void HitDetected(Collision collision);
    public HitDetected OnHit = (i) => {};

    public Animator itemAnimator;
    public float singleUseTime;

    private Pickable dropItem;

    private float cooldown = 0;
    private List<GameObject> ignore = new List<GameObject>();

    public void Use()
    {
        if (cooldown <= 0)
        {
            if (itemAnimator != null)
                itemAnimator.SetTrigger("Use");
            cooldown = singleUseTime;
            ignore.Clear();
        }
    }

    public void Drop()
    {
        Debug.Log("Drop item! Not implemented");
    }

    private void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == transform.parent.parent.gameObject ||
            ignore.IndexOf(collision.gameObject) >= 0)
            return;

        ignore.Add(collision.gameObject);
        OnHit(collision);

        DestructibleObject destructible = collision.gameObject.GetComponent<DestructibleObject>();
        if (destructible != null)
            destructible.GetHit();

        itemAnimator.SetTrigger("Stop");
    }
}
