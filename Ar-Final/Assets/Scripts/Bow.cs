using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Slider shootSlider;
    [SerializeField] private Transform arrowLocation;
    [SerializeField] private Transform followPoint;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followPoint.position, Time.deltaTime * speed);
        transform.rotation = followPoint.rotation;


        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                Shoot(shootSlider.value);
            }
        }

#if UNITY_EDITOR
        if (Input.GetButtonDown("Jump"))
        {
            Shoot(shootSlider.value);
        }
#endif
    }

    void Shoot(float force)
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowLocation);
        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        arrowRB.AddForce(-transform.forward * force, ForceMode.Impulse);
        GameManagerHunterAR.Instance.PlaySound(SoundType.BOW);
    }
}
