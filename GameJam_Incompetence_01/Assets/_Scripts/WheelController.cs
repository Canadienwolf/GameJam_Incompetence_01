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

        //wheelRot = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        //wheelRot = Mathf.Clamp(wheelRot, -15, 15);

        //frontWheelsTurner[0].transform.rotation = Quaternion.Euler(0, 0, 0);
        //frontWheelsTurner[1].transform.rotation = Quaternion.Euler(0, 0, 0);

        rearWheels[0].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
        rearWheels[1].transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * 500);
    }
}
