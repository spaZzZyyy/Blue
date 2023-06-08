using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public WorldPhysics worldPhysics;
    private Slider _dashCoolDownBar;
    private float _dashCoolDown;
    [SerializeField] private float dashAni;
    private bool _dashLoop;

    private void OnPlayerDash()
    {
        _dashLoop = true;
    }

    private void Update()
    {
        Actions.OnPlayerDeath -= Actions.OnPlayerDash;

        if (_dashLoop)
        {
            OnDash();
        }
    }

    private void Start()
    {
        _dashLoop = false;
        Actions.OnPlayerDash += OnPlayerDash;
        
        _dashCoolDown = worldPhysics.dashDuration;
        _dashCoolDownBar = gameObject.GetComponentInChildren<Slider>();
        _dashCoolDownBar.maxValue = worldPhysics.dashDuration;
        _dashCoolDownBar.value = worldPhysics.dashDuration;
    }

    private void OnDash()
    {
        _dashCoolDownBar.value = _dashCoolDown;
        
        if (_dashCoolDown > 0)
        {
            _dashCoolDown -= dashAni;
        }
        else
        {
            _dashCoolDown = worldPhysics.dashDuration;
            _dashLoop = false;
            _dashCoolDownBar.value = worldPhysics.dashDuration;
        }
    }

}
