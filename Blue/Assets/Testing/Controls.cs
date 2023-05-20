using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player Controls")]
public class Controls : ScriptableObject
{
    public KeyCode moveRight;
    public KeyCode moveLeft;
    public KeyCode moveJump;
    public KeyCode moveCrouch;
    public KeyCode atkShoot;
    public KeyCode atkRotateInvRight;
    public KeyCode atkRotateInvLeft;
}
