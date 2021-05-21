using UnityEngine;

public class AttackTransition : PlayerTransition
{
    [SerializeField] private PlayerInput _input;

    public override void Enable()
    {
        base.Enable();

        _input.Attack += OnAttack;
    }

    private void OnDisable()
    {
        _input.Attack -= OnAttack;
    }

    private void OnAttack()
    {
        NeedTransit = true;
    }
}
