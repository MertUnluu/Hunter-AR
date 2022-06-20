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
            GameManager_HunterAR.Instance.score += 1;
            GameManager_HunterAR.Instance.RemoveFromList(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(this);
        }
    }
}
