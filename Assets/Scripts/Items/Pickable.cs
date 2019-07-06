using System;
using System.Collections;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public InventoryItem item;
    public Animator pickAnimation;
    public Rigidbody body;
    public Collider collider;
    public float pickSpeed;
    public float pickDist = 1f;

    private Character character;
    private Vector3 pickedPosition;
    private Transform picker;
    private bool isPicked = false;


    public void PickBy(Character character)
    {
        if (body != null)
            body.detectCollisions = false;
        if (collider != null)
            collider.enabled = false;
        if (pickAnimation != null)
            pickAnimation.SetTrigger("Pick");
        picker = character.transform;
        this.character = character;
        pickedPosition = item.wearable.transform.position;

        isPicked = true;
    }

    private void Update()
    {
        if (isPicked) 
            AnimatePosition();
    }

    private void AnimatePosition()
    {
        Vector3 dist = picker.position + pickedPosition - transform.position;
        float sqrTime = Time.deltaTime * Time.deltaTime;
        if (dist.sqrMagnitude > pickSpeed * pickSpeed * sqrTime)
            transform.Translate(dist.normalized * pickSpeed * Time.deltaTime, transform.parent);
        else
            OnPicked();
    }

    private void OnPicked()
    {
        character.Pick(item);
        Destroy(gameObject);
    }
}
