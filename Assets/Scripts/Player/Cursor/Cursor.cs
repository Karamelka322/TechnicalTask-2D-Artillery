using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CursorPrefab _cursorPrefab;

    private CursorPrefab _cursor;

    public Vector3 PositionCursor => _cursor.transform.position;

    private void OnEnable()
    {
        SpawnCursor();

        _input.PressedTouch += OnPressedTouch;
    }

    private void OnDisable()
    {
        DeleteCursor();

        _input.PressedTouch -= OnPressedTouch;
    }

    private void OnPressedTouch(Vector2 touch)
    {
        _cursor.transform.position = _input.ConvertToWorldPoint(touch);
    }

    private void SpawnCursor()
    {
        if(_cursor == null)
        {
            _cursor = Instantiate(_cursorPrefab, transform);
        }
    }

    private void DeleteCursor()
    {
        if (_cursor != null)
        {
            Destroy(_cursor.gameObject);
        }
    }
}
