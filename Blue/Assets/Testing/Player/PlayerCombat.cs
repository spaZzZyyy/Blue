using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public WorldPhysics worldPhysics;
    private bool _damageLinger;
    private bool _preventMultipleHits;
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
        Debug.Log("Player Died");
        enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (_preventMultipleHits == false)
            {
                StartCoroutine(TakeDamage());
                _preventMultipleHits = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _damageLinger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _damageLinger = false;
        }
    }

    IEnumerator TakeDamage()
    {
        Actions.OnPlayerHit();
        yield return new WaitForSeconds(worldPhysics.timeAfterHit);
        _preventMultipleHits = false;
        if (_damageLinger)
        {
            StartCoroutine(TakeDamage());
        }
    }
}
