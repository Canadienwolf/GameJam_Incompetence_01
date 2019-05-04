using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Car attributes")]
    public float maxSpeed;
    public float acceleration;
    public float rotSpeed;

    [Header("Lives manegment")]
    public float lives = 100;
    public float bloodLeft = 100;
    public GameObject blood;
    public GameObject hospitalPointer;


    private float currentSpeed;
    private float speedInput;
    [HideInInspector] public float currentRot;
    private GameObject[] hospitals;
    private List<GameObject> pointers = new List<GameObject>();

    private void Start()
    {
        hospitals = GameObject.FindGameObjectsWithTag("Hospital");

        for (int i = 0; i < hospitals.Length; i++)
        {
            pointers.Add(Instantiate(hospitalPointer, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity));
            pointers[i].transform.parent = gameObject.transform;
            pointers[i].GetComponent<FaceTowards>().hospitalTarget = hospitals[i];
        }
    }

    void Update()
    {
        bloodLeft -= Time.deltaTime;

        if (lives <= 0 || bloodLeft <= 0)
        {
            print("you lose");
        }
    }

    void LateUpdate()
    {
        print(lives);
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, Time.deltaTime * acceleration);
        GetComponent<WheelController>().rotationSpeed = speedInput;

        if (Input.GetAxis("Vertical") != 0)
        {
            speedInput = Mathf.MoveTowards(speedInput, Input.GetAxis("Vertical"), Time.deltaTime);
        }
        else
        {
            speedInput = Mathf.MoveTowards(speedInput, 0, Time.deltaTime * 20 / currentSpeed);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed * speedInput);

        if (Mathf.Abs(speedInput) > 0.2f)
        {
            currentRot = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime * (2 / speedInput) * 10;
            currentRot = Mathf.Clamp(currentRot, -3, 3);
            transform.Rotate(Vector3.up * currentRot);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (currentSpeed > maxSpeed * 0.5f && col.gameObject.tag != "Ground")
        {
            lives -= currentSpeed / 5;
            print(lives);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hospital")
        {
            print("You win");
        }
    }
}
