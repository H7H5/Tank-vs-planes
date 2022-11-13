using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNuclear : MonoBehaviour
{
    [SerializeField]
    float speed;
    private Transform back_Tranform;
    private float back_pos_x;
    private float start_pos_y;
    void Start()
    {
        back_Tranform = GetComponent<Transform>();
        start_pos_y = GetComponent<SpriteRenderer>().transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ResetPositionX ()
    {
        back_pos_x = 0;
    }

    public void Move()
    {
        back_pos_x += speed * Time.deltaTime;
        back_Tranform.position = new Vector3(back_pos_x, start_pos_y, 0);
    }
}