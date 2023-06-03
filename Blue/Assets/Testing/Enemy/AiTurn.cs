using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AiTurn : MonoBehaviour
{
    [SerializeField] private Tags tagCheck;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.HasTag(tagCheck))
        {
            Actions.OnEnemyTurn();
        }
    }
}
