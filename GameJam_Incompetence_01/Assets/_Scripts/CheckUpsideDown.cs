using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUpsideDown : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            gameObject.transform.parent.GetComponent<PlayerController>().lives--;
        }
    }
}
