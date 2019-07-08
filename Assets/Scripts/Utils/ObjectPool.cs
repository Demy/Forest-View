using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int maxSize = 10;

    private List<GameObject> pooled = new List<GameObject>();

    public GameObject GetFromPool()
    {
        if (pooled.Count > 0)
        {
            GameObject item = pooled[0];
            pooled.RemoveAt(0);
            item.SetActive(true);
            return item;
        }
        return Instantiate(prefab);
    }

    public void ReturnToPool(GameObject item)
    {
        if (pooled.Count < maxSize)
        {
            item.SetActive(false);
            item.transform.SetParent(transform);
            pooled.Add(item);
            return;
        }
        Destroy(item.gameObject);
    }
}
