﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour {

    public float rotateSpeed = 10.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float move = Input.GetAxis("Horizontal");

        if (move < 0 || move > 0) transform.Rotate(Vector3.forward * -rotateSpeed);

    }
}
