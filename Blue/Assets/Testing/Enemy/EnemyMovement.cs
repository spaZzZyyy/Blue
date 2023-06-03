using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _enemyDirection;
    private Rigidbody2D _monsterRigidBody;
    public EnemyBehavior enemyBehavior;

    private void OnEnable()
    {
        Actions.OnEnemyTurn += OnEnemyTurn;
    }

    private void OnDisable()
    {
        Actions.OnEnemyTurn -= OnEnemyTurn;
    }

    private void OnEnemyTurn()
    {
        _enemyDirection *= -1;
    }

    void Start()
    {
        _monsterRigidBody = GetComponent<Rigidbody2D>();
        _enemyDirection = -1f;
    }
    
    private void FixedUpdate()
    {
        _monsterRigidBody.velocity = new Vector2(_enemyDirection * enemyBehavior.enemySpeed, _monsterRigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            OnEnemyTurn();
        }
    }
    
    
}
