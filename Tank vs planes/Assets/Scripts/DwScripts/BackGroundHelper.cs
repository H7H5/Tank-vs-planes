using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundHelper : MonoBehaviour
{
    public MoveBackGround[] moveBackGrounds;

    public void StopMoveBackGround()
    {
        foreach (MoveBackGround moveBackGround in moveBackGrounds)
        {
            moveBackGround.StopMoveBackGround();
        }
    }

    public void StartMoveBackGround()
    {
        foreach (MoveBackGround moveBackGround in moveBackGrounds)
        {
            moveBackGround.StartMoveBackGround();
        }
    }
}
