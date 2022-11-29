using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearSpeedBG : MonoBehaviour
{
    public MoveBackGround moveBackGround;

    public float GetMoveBackGroundSpeed()
    {
        return moveBackGround.GetSpeedBackGround();
    }
}
