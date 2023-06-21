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
    [SerializeField] private Transform groundCheck;
    private Rigidbody2D _playerRigidbody;
    private Animator _playerAni;
    
    private float _movementPlayer;
    private float _playerThickness;
    private bool _canDash = true;

    private float fallSpeed = 10;
    private float fallingSpeed = 0.25f;


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
        enabled = false;
    }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerThickness = transform.localScale.x;
        _playerAni = GetComponent<Animator>();

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
                Actions.OnPlayerDash();
                StartCoroutine(OnDash());
            }
        }

        #endregion

        #region Animation

        if (IsGrounded())
        {
            _playerAni.SetBool("Grounded", true);
        }
        else
        {
            _playerAni.SetBool("Grounded", false);
        }

        if (_movementPlayer != 0)
        {
            _playerAni.SetInteger("AnimState", 1);
        }
        else
        {
            _playerAni.SetInteger("AnimState", 0);
        }

        
        fallSpeed -= fallingSpeed;
        _playerAni.SetFloat("AirSpeedY", fallSpeed);
        

        if (Input.GetKeyDown(_moveJumpButton) && IsGrounded())
        {
            _playerAni.SetTrigger("Jump");
            fallSpeed = 10;
        }

        if (Input.GetKeyUp(_moveJumpButton) && _playerRigidbody.velocity.y > 0f)
        {
            fallSpeed = 5;
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