using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(HealthContainer))]
public class StateMachine : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected HealthContainer _healthContainer;

    public virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthContainer = GetComponent<HealthContainer>();
    }

    private void OnEnable()
    {
        _healthContainer.Died += OnDied;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnDied;        
    }

    public virtual void OnDied() { }
}
