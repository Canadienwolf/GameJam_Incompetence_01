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

        if (Input.GetAxis("Horizontal") != 0)
        {
            wheelRot = Mathf.MoveTowards(wheelRot, 15 * Input.GetAxis("Horizontal"), Time.deltaTime * 2);
        }
        else
        {
            wheelRot = Mathf.MoveTowards(wheelRot, 0, Time.deltaTime * 2);
        }

        frontWheelsTurner[0].transform.rotation = Quaternion.Euler(0, wheelRot, 0);
        frontWheelsTurner[1].transform.rotation = Quaternion.Euler(0, wheelRot, 0);

        rearWheels[0].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
        rearWheels[1].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
    }
}
