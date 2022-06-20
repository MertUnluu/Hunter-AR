using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    float randomFlyTÝme;
    float direction;
    float currentMovement;
    float speed;
    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        randomFlyTÝme = Random.Range(2.0f, 4.0f);
        direction = Random.value > 0.5f ? 1 : -1;
        speed = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentMovement += Time.deltaTime;
        if (currentMovement > randomFlyTÝme)
        {
            currentMovement = 0;
            direction *= -1;
        }
        Movement(Time.deltaTime);
    }

    void Movement(float DeltaTime)
    {
        transform.Translate(new Vector3(0, speed * DeltaTime * direction, 0));
    }
}
