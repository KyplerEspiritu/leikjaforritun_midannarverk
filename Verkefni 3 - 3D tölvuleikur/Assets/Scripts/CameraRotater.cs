﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float sensitivity = 1.25f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    CursorLockMode wantedMode;



    // Use this for initialization
    void Start()
    {
    	Cursor.visible = false;
    	Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X") * sensitivity;
        pitch -= speedV * Input.GetAxis("Mouse Y") * sensitivity;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}