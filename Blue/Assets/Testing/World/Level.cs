using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int timeAfterDeath;
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
        StartCoroutine(OnPlayerDieWait());
    }

    IEnumerator OnPlayerDieWait()
    {
        yield return new WaitForSeconds(timeAfterDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
