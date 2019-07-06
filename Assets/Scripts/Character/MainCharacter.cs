using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
{
    public SceneObjectController objects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            objects.TryPickClosest(this);
        }
        if (rightHand && Input.GetMouseButton(0))
        {
            rightHand.Use();
        }
    }
}
