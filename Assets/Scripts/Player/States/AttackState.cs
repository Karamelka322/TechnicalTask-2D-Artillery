using UnityEngine;

public class AttackState : PlayerState
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Cursor _cursor;
    [SerializeField] private Adility _adility;

    private CameraMovement _camera;

    private void Awake()
    {
        _camera = FindObjectOfType<CameraMovement>();
    }

    private void OnEnable()
    {
        _camera.Zoom(6.5f, 1f);

        _cursor.enabled = true;
        _adility.enabled = true;

        _input.UpTouch += OnUpTouch;
    }

    private void OnUpTouch(Vector2 touch)
    {
        _adility.Shoot(_input.ConvertToWorldPoint(touch), this);

        _camera.Zoom(5.5f, 1f);

        _adility.enabled = false;
        _cursor.enabled = false;

        _input.UpTouch -= OnUpTouch;
    }
}
