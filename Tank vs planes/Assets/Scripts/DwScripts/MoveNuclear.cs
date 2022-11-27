using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNuclear : MonoBehaviour
{
    [SerializeField]
    float speed;
    private float keepSpeed;
    private Transform back_Tranform;
    private float back_pos_x;
    private float start_pos_y;

    public MoveBackGround moveBackGround;

    void Start()
    {
        NuclearEventManager.OnStopMoveEnvironment.AddListener(StopMoveBackGround);
        NuclearEventManager.OnStartMoveEnvironment.AddListener(StartMoveBackGround);

        back_Tranform = GetComponent<Transform>();
        start_pos_y = GetComponent<SpriteRenderer>().transform.position.y;

        speed = moveBackGround.GetSpeedBackGround();
    }

    void Update()
    {
        Move();
    }

    public void ResetPositionX ()
    {
        back_pos_x = 0;
    }

    public void StopMoveBackGround()
    {
        if (speed != 0)
        {
            keepSpeed = speed;
        }
        speed = 0;
    }

    public void StartMoveBackGround()
    {
        if (speed == 0)
        {
            speed = keepSpeed;
        }
    }

    public void Move()
    {
        back_pos_x += speed * Time.deltaTime;
        back_Tranform.position = new Vector3(back_pos_x, start_pos_y, 0);
    }
}