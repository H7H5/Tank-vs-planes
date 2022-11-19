using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMegaLaser : MonoBehaviour
{
    private float value;
    public Slider slider;
    public float speed = 1;
    
    void Start()
    {
        value = slider.maxValue;
    }

    void Update()
    {
        if(slider.value > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = 4;
            }
            if (Input.GetMouseButtonUp(0))
            {
                speed = 1;
            }
        }

        value -= speed;
        slider.value = value;

        if(slider.value == 0)
        {
            slider.value = slider.maxValue;
            value = slider.maxValue;
            speed = 1;
            transform.parent.gameObject.SetActive(false);
        }
    }


}
