using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMarker : MonoBehaviour
{
    private float maxValue = 1200;
    private float value;

    [SerializeField]
    private float speed;

    void Start()
    {
        GetComponent<Slider>().maxValue = maxValue;
    }

    
    void Update()
    {
        value += speed * Time.deltaTime;
        GetComponent<Slider>().value = value;
    }
}
