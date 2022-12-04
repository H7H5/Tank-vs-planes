using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElementBackGround : MoveElements
{
    private float size_x;

    private void Start()
    {
        StartProperties();
        GetSizeX();
    }    

    private void Update()
    {
        Move();
        GroundRepeat();
    }

    private void GetSizeX()
    {
        size_x = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void GroundRepeat()
    {
        pos_x = Mathf.Repeat(pos_x, size_x);
    }

    public float GetSpeedElementBackGround()
    {
        return speed;
    }
}
