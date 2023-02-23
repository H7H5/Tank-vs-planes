using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneElements : MoveElements
{
    private float pos_x_destroy = - 20f;

    void Start()
    {
        StartPropertiesForElements();
    }

    void Update()
    {
        Move();
        CheckToDestroy();
    }

    public void SetSpeedSceneElement(float speedElement)
    {
        speed = speedElement;
    }

    private void CheckToDestroy()
    {
        if (pos_x < pos_x_destroy)
        {
            Destroy(gameObject);
        }
    }
}
