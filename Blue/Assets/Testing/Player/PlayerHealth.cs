using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public WorldPhysics worldPhysics;
    public HealthBar healthbar;
    private int _health;
    
    private void OnEnable()
    {
        Actions.OnPlayerHit += OnPlayerHit;
    }

    private void OnDisable()
    {
        Actions.OnPlayerHit -= OnPlayerHit;
    }

    private void Start()
    {
        _health = worldPhysics.maxHealth;
        healthbar.SetMaxHealth(worldPhysics.maxHealth);
    }

    private void OnPlayerHit()
    {
        _health -= worldPhysics.lightAttackDamage;
        healthbar.SetHp(_health);
        if (_health <= 0)
        {
            Actions.OnPlayerDeath();
        }
        
        //Debug.Log("Player Health: " + _health);
    }

}
