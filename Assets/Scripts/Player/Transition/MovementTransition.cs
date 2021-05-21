using UnityEngine;

public class MovementTransition : PlayerTransition
{
    [SerializeField] private PlayerInput _input;

    public override void Enable()
    {
        _input.FirstTouch += OnFirstTouch;
    }

    private void OnDisable()
    {
        _input.FirstTouch -= OnFirstTouch;
    }

    private void OnFirstTouch(Vector2 touch)
    {
        NeedTransit = true;
    }
}
