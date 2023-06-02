using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/World Physics")]
public class WorldPhysics : ScriptableObject
{
    public float gravityForce;
    public float movementSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public float groundCheckDistance;
    public float minJumpHeight;


}

