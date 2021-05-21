using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private Coroutine _coroutine;
    private Camera _camera;

    public Transform NowTarget { private get; set; }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        Vector3 nextPosition = Vector3.Lerp(transform.position, _target.position, Time.fixedDeltaTime * _speed);
        nextPosition.z = -10;

        transform.position = nextPosition;
    }

    public void Zoom(float value, float speed)
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ZoomMove(value, speed));
    }

    IEnumerator ZoomMove(float nextSize, float speed)
    {
        var size = _camera.orthographicSize;

        for (float i = 0; i < 1f; i += Time.deltaTime * speed)
        {
            _camera.orthographicSize = Mathf.Lerp(size, nextSize, i);
            yield return null;
        }

        _coroutine = null;
    }
}
