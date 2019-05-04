using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAI : MonoBehaviour
{
    //Speed of the vehicle
    private float speed = 5f;

    //3 choices of which if statement to take, so that it knows how many directions it can go
    private int turnDirection;

    //rotation value in the Y axis
    private float yRot;

    //the current rotation in the y axis that the vehicle currently has in the Y axis
    public float currentRot;

    //The speed that the vehicle can turn at
    public float rotSpeed;

    private bool isRotating;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag( "TrafficBox_1"))
        {
            print(1);
            StartCoroutine(SmoothRotate(true));

        }
    }

    private IEnumerator SmoothRotate(bool isRight)
    {
        if(isRotating)
            yield return null;

        isRotating = true;

        var side = isRight ? 1 : -1;
        var newRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + side*90f, transform.rotation.z);

        while (Quaternion.Angle(transform.rotation, newRotation) >= 0.5f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotSpeed);
            yield return new WaitForEndOfFrame();
        }

        isRotating = false;

    }
}
