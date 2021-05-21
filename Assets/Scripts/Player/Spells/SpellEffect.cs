using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    [SerializeField] private float _deleteTime;
    [SerializeField] private ParticleSystem[] _effects;

    [System.Obsolete]
    public void Delete()
    {
        transform.parent = null;

        for (int i = 0; i < _effects.Length; i++)
        {
            _effects[i].maxParticles = 0;
        }

        Destroy(gameObject, _deleteTime);
    }
}
