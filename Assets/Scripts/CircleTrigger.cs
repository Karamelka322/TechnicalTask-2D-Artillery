using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class CircleTrigger : MonoBehaviour
{
    public UnityAction<Collider2D> SituationTriggerStay;

    public CircleCollider2D CircleCollider { get; private set; }

    private void Awake()
    {
        CircleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SituationTriggerStay?.Invoke(collision);
    }
}
