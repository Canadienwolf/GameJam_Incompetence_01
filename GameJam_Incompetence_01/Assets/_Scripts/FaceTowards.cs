using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowards : MonoBehaviour
{
    public GameObject hospitalTarget;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(hospitalTarget.transform.position);
    }
}
