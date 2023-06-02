using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controls controls;
    public WorldPhysics worldPhysics;
    private Rigidbody2D _playerRigidbody;


    [SerializeField] private Transform groundCheck;
    private float _movementPlayer;
    private float _playerThickness;
    
    

    #region Asigning Controls

        private KeyCode _moveRightButton;
        private KeyCode _moveLeftButton;
        private KeyCode _moveJumpButton;
        private KeyCode _moveCrouchButton;
        private KeyCode _atkShootButton;
        private KeyCode _atkRotateInvRightButton;
        private KeyCode _atkRotateInvLeftButton;

    #endregion

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerThickness = transform.localScale.x;


        #region Asigning Controls

            _moveRightButton = controls.moveRight;
            _moveLeftButton = controls.moveLeft;
            _moveJumpButton = controls.moveJump;
            _moveCrouchButton = controls.moveCrouch;
            _atkShootButton = controls.atkShoot;
            _atkRotateInvLeftButton = controls.atkRotateInvLeft;
            _atkRotateInvRightButton = controls.atkRotateInvRight;

        #endregion

    }

    private void Update()
    {
        #region Run Input
            _movementPlayer = 0f;
            if (Input.GetKey(_moveRightButton))
            {
                _movementPlayer = 1f;
                Vector2 localScale = transform.localScale;
                localScale.x = _playerThickness;
                transform.localScale = localScale;
            }

            if (Input.GetKey(_moveLeftButton))
            {
                _movementPlayer = -1f;
                Vector2 localScale = transform.localScale;
                localScale.x = -_playerThickness;
                transform.localScale = localScale;
            }
        
        #endregion
        
        if (Input.GetKeyDown(_moveJumpButton) && IsGrounded())
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, worldPhysics.jumpForce);
        }

        if (Input.GetKeyUp(_moveJumpButton) && _playerRigidbody.velocity.y > 0f)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y * worldPhysics.minJumpHeight);
        }
    }

    private void FixedUpdate()
    {
        _playerRigidbody.gravityScale = worldPhysics.gravityForce;
        #region Movement
        //Run
            _playerRigidbody.velocity = new Vector2(_movementPlayer * worldPhysics.movementSpeed, _playerRigidbody.velocity.y);
            
        #endregion
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, worldPhysics.groundCheckDistance, worldPhysics.groundLayer);
    }
    
    
}