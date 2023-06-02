using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private UnityEvent _monsterEvent;
    public EnemyBehavior enemyBehavior;
    private float _enemyDirection;
    private Rigidbody2D _monsterRigidBody;
    
    
    void Start()
    {
        _monsterRigidBody = GetComponent<Rigidbody2D>();
        _enemyDirection = -1f;
        
    }

    private void FixedUpdate()
    {
        // _playerRigidbody.velocity = new Vector2(_movementPlayer * worldPhysics.movementSpeed, _playerRigidbody.velocity.y);

        _monsterRigidBody.velocity = new Vector2(_enemyDirection * enemyBehavior.enemySpeed, _monsterRigidBody.velocity.x);
    }
    
}
