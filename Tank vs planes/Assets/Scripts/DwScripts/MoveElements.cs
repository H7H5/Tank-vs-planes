using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElements : MonoBehaviour
{
    protected float speed;
    protected float keepSpeed;
    protected float pos_x;
    protected float pos_y;

    public SpeedElements speedElement;

    void Start()
    {
        StartProperties();
    }

    void Update()
    {
        Move();
    }

    protected void StartProperties()
    {
        NuclearEventManager.OnStopMoveEnvironment.AddListener(StopMoveElement);
        NuclearEventManager.OnStartMoveEnvironment.AddListener(StartMoveElement);
       
        pos_x = transform.position.x;
        pos_y = transform.position.y;

        SetSpeedElements(speedElement);
    }

    protected void StartPropertiesForElements()
    {
        NuclearEventManager.OnStopMoveEnvironment.AddListener(StopMoveElement);
        NuclearEventManager.OnStartMoveEnvironment.AddListener(StartMoveElement);

        pos_x = transform.position.x;
        pos_y = transform.position.y;
    }

    public enum SpeedElements
    {
        Ground,
        BackGround,
        BehindBackGround,
        Sky
    }

    protected void SetSpeedElements(SpeedElements speedElement)
    {
        switch (speedElement)
        {
            case SpeedElements.Ground:
                speed = -4f;
                break;
            case SpeedElements.BackGround:
                speed = -2f;
                break;
            case SpeedElements.BehindBackGround:
                speed = -1f;
                break;
            case SpeedElements.Sky:
                speed = -0.5f;
                break;
            default:
                speed = 0f;
                break;
        }
    }

    protected void StopMoveElement()
    {
        if (speed != 0)
        {
            keepSpeed = speed;
        }
        speed = 0;
    }

    protected void StartMoveElement()
    {
        if (speed == 0)
        {
            speed = keepSpeed;
        }
    }

    protected void Move()
    {
        pos_x += speed * Time.deltaTime;
        transform.position = new Vector2(pos_x, pos_y);
    }
}
