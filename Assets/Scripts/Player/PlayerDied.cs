using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private HealthContainer _healthContainer;
    [SerializeField] private PlayerInput _input;
    [Space]
    [SerializeField] private GameObject _targetWindow;

    private void OnEnable()
    {
        _healthContainer.Died += OnDied;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnDied;
    }

    private void OnDied()
    {
        _targetWindow.SetActive(true);
        _input.enabled = false;
    }
}
