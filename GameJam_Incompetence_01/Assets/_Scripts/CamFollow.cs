using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public Transform camPos;

    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPos = camPos.transform.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, camPos.transform.rotation, smoothSpeed * Time.deltaTime);
    }
}
