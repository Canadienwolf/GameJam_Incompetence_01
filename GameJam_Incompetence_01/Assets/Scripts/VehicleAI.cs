using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class VehicleAI : MonoBehaviour
{

    private List<Transform> nodes = new List<Transform>();

    public float movementSpeed = 0.5f;
    public Color lineColor;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * movementSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        Transform[] pathTransform = GetComponentsInChildren<Transform>();

    }
}
