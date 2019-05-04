using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public Transform camPos;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPos = camPos.transform.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        //transform.RotateAround(player.transform.position, Vector3.up, player.GetComponent<PlayerController>().currentRot);

        transform.LookAt(player.transform.position);
    }
}
