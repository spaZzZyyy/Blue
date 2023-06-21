using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashParticalController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private ParticleSystemRenderer ps;
    [SerializeField] private Vector3 psDirection;
    private void OnEnable()
    {
        ps = GetComponent<ParticleSystemRenderer>();
        Actions.OnPlayerDash += OnPlayerDash;
    }

    private void OnDisable()
    {
        Actions.OnPlayerDash -= OnPlayerDash;
    }

    private void OnPlayerDash()
    {
        ps.flip = psDirection;
    }

    private void Update()
    {
        if (playerTransform.localScale.x > 0)
        {
            psDirection.x = 0;
        }
        if (playerTransform.localScale.x < 0)
        {
            psDirection.x = 1;
        }
    }
}
