using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    float randomFlyTÝme;
    float directionX;
    float directionZ;
    float currentMovement;
    float speed;
    Transform transform;
    Transform arOrigin;

    // Start is called before the first frame update
    void Start()
    {
        arOrigin = GameManagerHunterAR.Instance.ArOrigin;
        transform = GetComponent<Transform>();
        randomFlyTÝme = Random.Range(2.0f, 4.0f);
        directionX = Random.value > 0.5f ? 1 : -1;
        directionZ = Random.value > 0.5f ? 1 : -1;
        speed = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentMovement += Time.deltaTime;
        if (currentMovement > randomFlyTÝme)
        {
            currentMovement = 0;
            directionX *= -1;
            directionZ *= -1;
        }
        Movement(Time.deltaTime);
        transform.LookAt(arOrigin);
    }

    void Movement(float DeltaTime)
    {
        transform.Translate(new Vector3(directionX * speed *DeltaTime, 0, directionZ * DeltaTime * speed), Space.World);
    }
}
