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
        if (other.tag == "TrafficBox_1")
        {
            transform.rotation = Quaternion.Euler(transform.rotation.y, currentRot + 90, yRot);
        }
    }
}
