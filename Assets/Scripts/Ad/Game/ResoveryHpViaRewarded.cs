using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResoveryHpViaRewarded : MonoBehaviour
{
    [SerializeField] private Rewarded _rewardedAd;
    [Space]
    [SerializeField] private HealthContainer _healthContainer;
    [SerializeField] private PlayerInput _input;
    [Space]
    [SerializeField] private UnityEvent _rewardedEvent;

    public void ShowRewarded()
    {
        _rewardedAd._rewarded = _rewardedEvent;
        _rewardedAd.Show();
    }

    public void Rewarded()
    {
        _healthContainer.ValueHealth = 50;
        _input.enabled = true;
    }
}
