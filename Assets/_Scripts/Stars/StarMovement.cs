using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        _transform.Rotate(0,0.1f,0);
    }
}
    