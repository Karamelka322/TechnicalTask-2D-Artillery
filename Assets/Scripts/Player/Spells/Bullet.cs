using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [Space]
    [SerializeField] private ParticleSystem _moveEffect;
    [SerializeField] private ParticleSystem _boomEffectPrefab;

    private Rigidbody2D _rigidbody;

    public Vector3 Direction { private get; set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Ground ground))
        {
            DisableMoveEffect();
            SpawnBoomEffect();

            Destroy(gameObject);
        }
        
        if (collision.transform.TryGetComponent(out IDamageble damageble))
        {
            damageble.ApplyDamage(_damage);

            DisableMoveEffect();
            SpawnBoomEffect();

            Destroy(gameObject);
        }
    }

    private void Move()
    {
        _rigidbody.MovePosition(transform.position + Direction * _speed);
    }

    private void DisableMoveEffect()
    {
        if (_moveEffect)
        {
            _moveEffect.transform.parent = null;
            _moveEffect.Stop();
        }
    }

    private void SpawnBoomEffect()
    {
        if(_boomEffectPrefab)
        {
            Instantiate(_boomEffectPrefab, transform.position, Quaternion.identity, null);
        }
    }
}
