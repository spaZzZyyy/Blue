using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float camFrames;
    private float elapsedFrames = 0;
    private Vector3 _position;
    private bool _moveCam = false;

    private void Start()
    {
        _position = transform.position;
    }

    private void Update()
    {
        if (_moveCam)
        {
            elapsedFrames += Time.deltaTime;
            float percentageComplete = elapsedFrames / camFrames;

            cam.transform.position = Vector3.Lerp(cam.transform.position, _position, percentageComplete);
            if (cam.transform.position == _position)
            {
                _moveCam = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _moveCam = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _moveCam = true;
        }
    }
}
