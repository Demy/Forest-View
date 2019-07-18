using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int maxHit = 3;
    public GameObject destroyedPrefab;

    private int hp;

    private void Start()
    {
        hp = maxHit;
    }

    public void GetHit()
    {
        if (--hp <= 0)
        {
            SceneObjectController scene = FindObjectOfType<SceneObjectController>();
            if (destroyedPrefab != null)
            {
                GameObject destroyed = Instantiate(destroyedPrefab, transform.parent);
                destroyed.transform.position = transform.position;
                destroyed.transform.rotation = transform.rotation;
                scene.UpdatePickablesFrom(destroyed.transform);
            }
            scene.RemovePickablesFrom(transform);
            Destroy(gameObject);
        }
    }
}
