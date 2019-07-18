using System;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
{
    public MovementControls movement;

    public SceneObjectController objects;

    public override void Freeze(bool freeze)
    {
        movement.enabled = !freeze;
        base.Freeze(freeze);
    }

    private void Update()
    {
        if (!movement.enabled) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            objects.TryPickClosest(this);
        }
        if (rightHand && Input.GetMouseButton(0))
        {
            rightHand.Use();
        }
    }

    public override void Pick(InventoryItem item)
    {
        base.Pick(item);
    }
}
