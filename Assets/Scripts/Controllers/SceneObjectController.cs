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
            character.Freeze(true);
            pickables.Remove(closest);
            closest.PickBy(character);
        }
    }

    public void UpdatePickablesFrom(Transform parent)
    {
        Pickable item = parent.GetComponent<Pickable>();
        if (item != null)
            pickables.Add(item);
        for (int i = 0; i < parent.childCount; i++)
            UpdatePickablesFrom(parent.GetChild(i));
    }

    public void RemovePickablesFrom(Transform parent)
    {
        Pickable item = parent.GetComponent<Pickable>();
        if (item != null)
            pickables.Remove(item);
        for (int i = 0; i < parent.childCount; i++)
            RemovePickablesFrom(parent.GetChild(i));
    }
}
