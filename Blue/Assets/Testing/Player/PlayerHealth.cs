using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public WorldPhysics worldPhysics;
    public int health;
    
    private void OnEnable()
    {
        Actions.OnPlayerHit += OnPlayerHit;
    }

    private void OnDisable()
    {
        Actions.OnPlayerHit -= OnPlayerHit;
    }

    private void OnPlayerHit()
    {
        health -= worldPhysics.lightAttackDamage;
        
        if (health <= 0)
        {
            Actions.OnPlayerDeath();
        }
    }

    private void Update()
    {
        Debug.Log("Player Health: " + health);
    }
}
