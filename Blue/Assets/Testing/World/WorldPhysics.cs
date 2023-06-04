using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/World Physics")]
public class WorldPhysics : ScriptableObject
{
    //Movement
    public float gravityForce;
    public float movementSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public float groundCheckDistance;
    public float minJumpHeight;
    public float dashDistance;
    public float dashCoolDown;
    public float dashDuration;
    public float timeAfterHit;

    //Combat
    public int lightAttackDamage;
    public int heavyAttackDamage;

}

