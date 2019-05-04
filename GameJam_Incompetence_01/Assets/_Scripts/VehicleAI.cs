using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAI : MonoBehaviour
{

    public float movementSpeed = 0.5f;


    private float currentRot;
    public float yRot;
    public int turnDirection = 3;



    // Start is called before the first frame update
    void Start()
    {

        currentRot = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        if (turnDirection == 1)
        {
            yRot += Time.deltaTime * movementSpeed;
            transform.rotation = Quaternion.Euler(0, Mathf.MoveTowards(transform.rotation.y, currentRot + 90, yRot), 0);
        }
        else if (turnDirection == 0)
        {
            yRot += Time.deltaTime * movementSpeed;
            transform.rotation = Quaternion.Euler(0, Mathf.MoveTowards(transform.rotation.y, currentRot - 90, yRot), 0);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "TrafficBox")
        {
            //transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }

        if (collider.gameObject.tag == "Right/Left_Turn")
        {
            turnDirection = Random.Range(0, 2);
            
        }

        if (GameObject.FindGameObjectWithTag(""))
        {
            
        }

    }
}
