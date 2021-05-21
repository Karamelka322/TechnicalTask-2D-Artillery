using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _radiusTouchForAttack;

    public UnityAction Attack;
    public UnityAction<Vector2> FirstTouch;
    public UnityAction<Vector2> PressedTouch;
    public UnityAction<Vector2> UpTouch;

    private Camera _camera;
    private Vector2 _firstTouch;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckRadiusTouchForAttack())
            {
                Attack?.Invoke();
                return;
            }

            FirstTouch?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
            PressedTouch?.Invoke(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
            UpTouch?.Invoke(Input.mousePosition);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc((Vector2)transform.position, Vector3.back, _radiusTouchForAttack);
    }
#endif

    private bool CheckRadiusTouchForAttack()
    {
        _firstTouch = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(transform.position, _firstTouch) < _radiusTouchForAttack)
        {
            return true;
        }

        return false;
    }

    public Vector3 ConvertToWorldPoint(Vector2 touch)
    {
        return _camera.ScreenToWorldPoint(touch);
    }
}
