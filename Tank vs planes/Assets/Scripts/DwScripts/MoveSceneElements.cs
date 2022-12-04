using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneElements : MoveElements
{
    private float pos_x_destroy = - 20f;

    void Start()
    {
        StartProperties();
    }

    void Update()
    {
        Move();
        CheckToDestroy();
    }

    private void CheckToDestroy()
    {
        if (pos_x < pos_x_destroy)
        {
            Destroy(gameObject);
        }
    }
}
