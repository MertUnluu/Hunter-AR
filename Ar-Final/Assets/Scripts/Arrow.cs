using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ZORT");
        if (collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Balloon"))
        {
            Debug.Log("ZURT");
            Destroy(collision.gameObject);
            Destroy(this);
        }
    }
}
