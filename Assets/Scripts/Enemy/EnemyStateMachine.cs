using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine, IDamageble
{
    [SerializeField] private EnemyState _firstState;

    private EnemyState _currentState;
    public PlayerStateMachine Player { get; private set; }

    private void Start()
    {
        Player = FindObjectOfType<PlayerStateMachine>();

        _currentState = _firstState;
        _currentState.Enter(_rigidbody);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        EnemyState nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(EnemyState state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter(_rigidbody);
    }

    public void ApplyDamage(int damage)
    {
        _healthContainer.TakeDamage(damage);
    }

    public override void OnDied()
    {
        if (_currentState != null)
            _currentState = null;

        enabled = false;
    }
}
