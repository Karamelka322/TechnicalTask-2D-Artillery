using System.Collections;
using UnityEngine;

public class JumpingTransition : PlayerTransition
{
    [SerializeField] private PlayerInput _input;
    [Space]
    [SerializeField] private float _recoveryTime;

    private Vector2 _firstTouch;
    private bool isDoubleTouch;
    private int _counterTouch;
    private float _time;

    public override void Enable()
    {
        base.Enable();

        _counterTouch = 0;
        isDoubleTouch = false;

        _input.FirstTouch += OnFirstTouch;
    }

    private void OnDisable()
    {
        _input.FirstTouch -= OnFirstTouch;        
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time > _recoveryTime && isDoubleTouch)
        {
            NeedTransit = true;
            isDoubleTouch = false;

            _time = 0;
        }
    }

    private void OnFirstTouch(Vector2 touch)
    {
        if (!isDoubleTouch)
        {
            if (_counterTouch == 0)
            {
                StartCoroutine(SearchDoubleTouch());
                _firstTouch = touch;
                _counterTouch++;
            }
            else if(_counterTouch == 1)
            {
                if (SearchFirstTouchInRadius(10))
                {
                    _counterTouch++;
                }
                else
                {
                    _firstTouch = touch;
                }
            }
        }

        bool SearchFirstTouchInRadius(float radius)
        {
            return (touch.x > _firstTouch.x - radius || touch.x < _firstTouch.x + radius) || (touch.y > _firstTouch.y - radius || touch.y < _firstTouch.y + radius);
        }
    }

    IEnumerator SearchDoubleTouch()
    {
        float maxWaitingTime = 0.4f;

        while (maxWaitingTime > 0)
        {
            if (_counterTouch == 2)
            {
                isDoubleTouch = true;
            }

            maxWaitingTime -= Time.deltaTime;

            yield return null;
        }

        _counterTouch = 0;
    }
}
