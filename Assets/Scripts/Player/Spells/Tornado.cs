using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Spells/Tornado", fileName = "Tornado", order = 51)]
public class Tornado : Spell
{
    [SerializeField] private CircleTrigger _circleTriggerPrefab;
    [SerializeField] private ParticleSystem _tornadoEffectPrefab;
    [Space]
    [SerializeField] private float _force;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _radius;

    private CircleTrigger _circleTrigger;

    public override void Shoot(Vector2 touchPoint, State state)
    {
        _circleTrigger = Instantiate(_circleTriggerPrefab, new Vector3(touchPoint.x, touchPoint.y, state.transform.position.z), Quaternion.identity);

        _circleTrigger.CircleCollider.radius = _radius;
        _circleTrigger.SituationTriggerStay += OnSituationTriggerStay;

        var _tornadoEffect = Instantiate(_tornadoEffectPrefab, _circleTrigger.transform.position, Quaternion.identity, _circleTrigger.transform);

        Destroy(_circleTrigger.gameObject, _lifeTime);
    }

    private void OnDisable()
    {
        if (_circleTrigger)
            _circleTrigger.SituationTriggerStay -= OnSituationTriggerStay;
    }

    private void OnSituationTriggerStay(Collider2D collision)
    {
        if(collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.AddForce((_circleTrigger.transform.position - rigidbody.transform.position) * _force);
        }
    }
}
