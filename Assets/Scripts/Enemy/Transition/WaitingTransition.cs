using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingTransition : EnemyTransition
{
    [SerializeField] private float _maxWaitingTime;

    private float _time;

    public override void Enable()
    {
        base.Enable();

        _time = 0;
    }

    private void Update()
    {
        if (TargetState.enabled)
            enabled = false;

        _time += Time.deltaTime;

        if (_time > _maxWaitingTime)
        {
            NeedTransit = true;
        }
    }
}
