using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    float direction = 1;
    float speed = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += Time.deltaTime * direction * speed;
        if (slider.value >= slider.maxValue && direction == 1)
        {
            direction = -1;
            
        }
        else if (slider.value <= slider.minValue && direction == -1)
        {
            direction = 1;
        }
    }
}
