using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controls controls;
    public WorldPhysics worldPhysics;
    private Rigidbody2D _playerRigidbody;


    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheckRight;
    [SerializeField] private Transform wallCheckLeft;


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


    private void FixedUpdate()
    {
        #region Control Input
        //Run
            
            if (Input.GetKey(_moveRightButton))
            {
                
            }
            if (Input.GetKey(_moveLeftButton))
            {
                
            }

            #endregion

            #region Physics

                #region Gravity

                    

                #endregion

            #endregion
    }
}
