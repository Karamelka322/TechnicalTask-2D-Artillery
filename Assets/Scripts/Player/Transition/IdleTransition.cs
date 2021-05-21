using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : PlayerTransition
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
        _time += Time.deltaTime;

        if (_time > _maxWaitingTime)
        {
            NeedTransit = true;
        }
    }
}
