﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform doodlePos;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (doodlePos.position.y > transform.position.y)
        {
            _transform.position = new Vector3(transform.position.x, doodlePos.position.y, transform.position.z); 
        }
    }
}
