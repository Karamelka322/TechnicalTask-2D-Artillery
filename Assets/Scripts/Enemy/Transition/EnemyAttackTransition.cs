using UnityEngine;
using UnityEditor;

public class EnemyAttackTransition : EnemyTransition
{
    [SerializeField] private EnemyStateMachine _enemy;
    [Space]
    [SerializeField] private float _maxDistanceToPlayer;

    private void LateUpdate()
    {
        if(Vector2.Distance(transform.position, _enemy.Player.transform.position) < _maxDistanceToPlayer)
        {
            NeedTransit = true;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc((Vector2)transform.position, Vector3.back, _maxDistanceToPlayer);
    }
#endif
}
