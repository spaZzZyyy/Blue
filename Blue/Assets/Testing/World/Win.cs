using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnPlayerWin += OnPlayerWin;
    }

    private void OnDisable()
    {
        Actions.OnPlayerWin -= OnPlayerWin;
    }

    private void OnPlayerWin()
    {
        Debug.Log("You Win");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Actions.OnPlayerWin();
    }
}
