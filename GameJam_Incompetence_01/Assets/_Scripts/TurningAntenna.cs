using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningAntenna : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
}
