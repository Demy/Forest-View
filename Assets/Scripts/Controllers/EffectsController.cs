using UnityEngine;
using System.Collections;

public class EffectsController : MonoBehaviour
{
    public enum EffectType
    {
        Default,
        Wood
    }

    public ObjectPool woodenParticles;

    public void SpawnParticles(Vector3 point, EffectType type)
    {
        ObjectPool pool = GetPoolByType(type);
        ParticleSystem effect = pool.GetFromPool().GetComponent<ParticleSystem>();
        effect.transform.position = point;
        effect.Play();
        StartCoroutine(RemoveEffect(pool, effect.gameObject, effect.main.duration));
    }

    IEnumerator RemoveEffect(ObjectPool pool, GameObject effect, float afterSeconds)
    {
        yield return new WaitForSeconds(afterSeconds);
        pool.ReturnToPool(effect);
    }

    private ObjectPool GetPoolByType(EffectType type)
    {
        switch (type)
        {
            case EffectType.Wood:
                return woodenParticles;
        }
        return woodenParticles;
    }
}
