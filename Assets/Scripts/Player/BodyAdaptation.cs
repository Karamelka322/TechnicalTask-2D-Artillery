using UnityEngine;
using DG.Tweening;

public class BodyAdaptation : MonoBehaviour
{
    [SerializeField] private Body _body;
    [SerializeField] private float _tiltAngle;

    private void OnEnable()
    {
        _body.CollisionWithGround += OnCollisionWithGround;
    }

    private void OnDisable()
    {
        _body.CollisionWithGround -= OnCollisionWithGround;
    }

    private void OnCollisionWithGround(Collision2D collision)
    {
        BodyAlignment(collision.contacts[0].point);
    }

    private void BodyAlignment(Vector2 point)
    {
        var direction = point - (Vector2)transform.position;
        var angle = GetAngle(direction.x, direction.y) + 90;
        angle = Mathf.Clamp(angle, -_tiltAngle, _tiltAngle);

        transform.DOLocalRotate(new Vector3(0, 0, angle), 1f, RotateMode.Fast);

        float GetAngle(float relativeX, float relativeY)
        {
            return Mathf.Atan2(relativeY, relativeX) * Mathf.Rad2Deg;
        }
    }
}
