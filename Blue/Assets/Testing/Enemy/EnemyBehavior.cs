using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/EnemyBehavior")]
public class EnemyBehavior : ScriptableObject
{
    public float enemySpeed;
    public float enemyJumpHeight;
    public int enemyDamage;
}
