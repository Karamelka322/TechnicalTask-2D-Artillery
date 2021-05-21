using UnityEngine;

public class MovementState : PlayerState
{
    [SerializeField] private PlayerInput _input;
    [Space]
    [SerializeField] private float _speed;

    private bool isMoving;
    private Vector2 _direction;

    private void OnEnable()
    {
        isMoving = true;

        _input.FirstTouch += OnFirstTouch; 
        _input.PressedTouch += OnPressedTouch;
        _input.UpTouch += OnUpTouch;         
    }

    private void OnDisable()
    {
        _input.FirstTouch -= OnFirstTouch; 
        _input.PressedTouch -= OnPressedTouch;        
        _input.UpTouch -= OnUpTouch;        
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Rigidbody.AddRelativeForce(_direction * _speed, ForceMode2D.Impulse);
        }
    }

    private void OnFirstTouch(Vector2 touch)
    {
        isMoving = true;
    }

    private void OnPressedTouch(Vector2 touch)
    {
        if (Screen.width / 2 < touch.x)
        {
            _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.left;
        }

        FlipPlayer(_direction);
    }

    private void OnUpTouch(Vector2 touch)
    {
        isMoving = false;
        _direction = Vector2.zero;
    }

    private void FlipPlayer(Vector2 direction)
    {
        var scale = Rigidbody.transform.localScale;

        if (CheckScale())
            scale = new Vector2(-scale.x, scale.y);

        Rigidbody.transform.localScale = scale;

        bool CheckScale()
        {
            return (direction.x > 0 && scale.x < 0) || (direction.x < 0 && scale.x > 0);
        }
    }
}
