using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public GameObject[] frontWheels;
    public GameObject[] frontWheelsTurner;
    public GameObject[] rearWheels;

    [HideInInspector] public float rotationSpeed;

    private float wheelRot;

    void FixedUpdate()
    {
        frontWheels[0].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
        frontWheels[1].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);

        wheelRot = Mathf.MoveTowards(wheelRot, Input.GetAxis("Horizontal") * 20, Time.deltaTime * 100);

        frontWheelsTurner[0].transform.localRotation = Quaternion.Euler(0, wheelRot, 0);
        frontWheelsTurner[1].transform.localRotation = Quaternion.Euler(0, wheelRot, 0);

        rearWheels[0].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
        rearWheels[1].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
    }
}
