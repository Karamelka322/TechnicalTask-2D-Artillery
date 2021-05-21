using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStateMachine : StateMachine, IDamageble
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _currentState;

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        PlayerState nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(PlayerState state)
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
