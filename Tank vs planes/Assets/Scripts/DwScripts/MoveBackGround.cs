using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    [SerializeField]
    float speed;
    private float keepSpeed;
    private Transform back_Tranform;
    private float back_Size_x;
    private float back_pos_x;
    private float start_pos_y;
    void Start()
    {
        back_Tranform = GetComponent<Transform>();
        back_Size_x = GetComponent<SpriteRenderer>().bounds.size.x;
        start_pos_y = GetComponent<SpriteRenderer>().transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void StopMoveBackGround()
    {
        if(speed != 0)
        {
            keepSpeed = speed;
        }
        speed = 0;
    }

    public void StartMoveBackGround()
    {
        if(speed == 0)
        {
            speed = keepSpeed;
        }
    }

    public void Move()
    {
        back_pos_x += speed * Time.deltaTime;
        back_pos_x = Mathf.Repeat(back_pos_x, back_Size_x);
        back_Tranform.position = new Vector3(back_pos_x, start_pos_y, 0);
    }
}
