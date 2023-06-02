using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public static event Action<float> onPlayerHurt;
    public static event Action<float> onPlayerGainHp;
    public static event Action onPlayerDeath;
    private BoxCollider2D _playerHitBox;
    public EnemyBehavior enemyBehavior;

    private void Start()
    {
        _playerHitBox = GetComponent<BoxCollider2D>();
    }

    public void removeHp(int amount)
    {
        Debug.Log("Player hp: " + health);
        health -= amount;
        onPlayerHurt?.Invoke(health);

        if (health <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }

    public void addHp(int amount)
    {
        health += amount;
        onPlayerGainHp?.Invoke(health);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            removeHp(enemyBehavior.enemyDamage);
        }
    }
}
