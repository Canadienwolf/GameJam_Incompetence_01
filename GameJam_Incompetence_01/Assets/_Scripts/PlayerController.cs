﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float rotSpeed;

    private float currentSpeed;
    private float speedInput;
    private float currentRot;

    void FixedUpdate()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, Time.deltaTime * acceleration);
        GetComponent<WheelController>().rotationSpeed = speedInput;

        if (Input.GetAxis("Vertical") != 0)
        {
            speedInput = Mathf.MoveTowards(speedInput, Input.GetAxis("Vertical"), Time.deltaTime);
        }
        else
        {
            speedInput = Mathf.MoveTowards(speedInput, 0, Time.deltaTime);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed * speedInput);

        if (speedInput != 0)
        {
            currentRot = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime * 10 * speedInput;
            transform.Rotate(Vector3.up * currentRot);
        }
    }
}
