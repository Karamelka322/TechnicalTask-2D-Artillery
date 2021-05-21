using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    [SerializeField] private EnemyStateMachine _enemy;
    [SerializeField] private Spell _spell;

    private void OnEnable()
    {
        Shoot();
    }

    private void Shoot()
    {
        _spell.Shoot(_enemy.Player.transform.position, this);
    }
}
