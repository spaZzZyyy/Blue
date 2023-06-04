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

    private bool _canDash = true;
    
    

    #region Asigning Controls

        private KeyCode _moveRightButton;
        private KeyCode _moveLeftButton;
        private KeyCode _moveJumpButton;
        private KeyCode _moveCrouchButton;
        private KeyCode _atkShootButton;
        private KeyCode _atkRotateInvRightButton;
        private KeyCode _atkRotateInvLeftButton;
        private KeyCode _moveDashButton;

    #endregion

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
            _moveDashButton = controls.dash;

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

        #region Jump
            if (Input.GetKeyDown(_moveJumpButton) && IsGrounded())
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, worldPhysics.jumpForce);
            }

            if (Input.GetKeyUp(_moveJumpButton) && _playerRigidbody.velocity.y > 0f)
            {
                _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y * worldPhysics.minJumpHeight);
            }
        

        #endregion

        #region Dash

        if (Input.GetKey(_moveDashButton))
        {
            if (_canDash)
            {
                _playerRigidbody.AddForce(new Vector2(worldPhysics.dashDistance * _movementPlayer, 0));
                StartCoroutine(OnDash());
            }
        }

        #endregion
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

    IEnumerator OnDash()
    {
        yield return new WaitForSeconds(worldPhysics.dashDuration);
        _canDash = false;
        yield return new WaitForSeconds(worldPhysics.dashCoolDown);
        _canDash = true;
    }
    
    
}