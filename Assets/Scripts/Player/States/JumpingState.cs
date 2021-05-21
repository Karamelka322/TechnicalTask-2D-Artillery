using UnityEngine;

public class JumpingState : PlayerState
{
    [SerializeField] private float _force;

    private void OnEnable()
    {
        Jump();
    }

    private void Jump()
    {
        Rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }
}
