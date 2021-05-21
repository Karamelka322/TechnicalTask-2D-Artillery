using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    [SerializeField] private PlayerTransition[] _transitions;

    public void Enter(Rigidbody2D rigidbody)
    {
        if (!enabled)
        {
            Rigidbody = rigidbody;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            enabled = false;

            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }
    }

    public PlayerState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
