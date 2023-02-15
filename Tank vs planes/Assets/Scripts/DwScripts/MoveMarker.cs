using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMarker : MonoBehaviour
{
    private float maxValue = 1200;
    private float value;
    private bool isArrived = false;

    private float valueToShowDangerIcon = 1100;

    [SerializeField]
    private float speed;

    public GameObject dangerIcon;

    void Start()
    {
        GetComponent<Slider>().maxValue = maxValue;
    }

    private void FixedUpdate()
    {
        value += speed * Time.deltaTime;
        GetComponent<Slider>().value = value;

        if (value >= maxValue && !isArrived)
        {
            isArrived = true;
            IconsController.Instance.StopMoveEnvironment();
        }

        if(value >= valueToShowDangerIcon && value < maxValue)
        {
            dangerIcon.SetActive(true);
        } 
        else
        {
            dangerIcon.SetActive(false);
        }
    }
}
