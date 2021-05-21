using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Body : MonoBehaviour
{
    public UnityAction<Collision2D> CollisionWithGround;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out Ground ground))
        {
            CollisionWithGround?.Invoke(collision);
        }
    }
}
