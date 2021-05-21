using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : Transition
{
    [SerializeField] private EnemyState _targetState;
    public EnemyState TargetState => _targetState;
}
