using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        Actions.OnPlayerDeath -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Actions.OnPlayerHit();
        }
    }
}
