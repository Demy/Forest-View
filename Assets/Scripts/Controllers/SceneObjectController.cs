using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectController : MonoBehaviour
{
    private List<Pickable> pickables;

    void Start()
    {
        pickables = new List<Pickable>(FindObjectsOfType<Pickable>());
    }

    public void TryPickClosest(Character character)
    {
        Pickable closest = null;
        Vector3 minDist = new Vector3();
        for (int i = 0; i < pickables.Count; i++)
        {
            Pickable item = pickables[i];
            Vector3 dist = item.transform.position - character.transform.position;
            if (dist.sqrMagnitude <= item.pickDist * item.pickDist)
            {
                if (closest == null || minDist.sqrMagnitude > dist.sqrMagnitude)
                {
                    if (!character.CanPick(item.item))
                        continue;
                    closest = item;
                    minDist = dist;
                }
            }
        }
        if (closest != null)
        {
            character.Freeze();
            closest.PickBy(character);
        }
    }
}
