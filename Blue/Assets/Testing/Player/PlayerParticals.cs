using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticals : MonoBehaviour
{
    [SerializeField] private float playerDashTrailTime;
    private ParticleSystem _playerPartical;
    public Controls controls;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerPartical = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        Actions.OnPlayerDash += OnPlayerDash;
    }

    private void OnDisable()
    {
        Actions.OnPlayerDash -= OnPlayerDash;
    }

    private void OnPlayerDash()
    {
        StartCoroutine(OnDash());
    }

    IEnumerator OnDash()
    {
        _playerPartical.Play();
        yield return new WaitForSeconds(playerDashTrailTime);
        _playerPartical.Stop();
    }
    
}
