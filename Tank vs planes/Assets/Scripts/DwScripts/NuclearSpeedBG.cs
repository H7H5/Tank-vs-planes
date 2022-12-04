using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearSpeedBG : MonoBehaviour
{
    public MoveElementBackGround moveBehindBackGround;

    public float GetMoveBackGroundSpeed()
    {
        return moveBehindBackGround.GetSpeedElementBackGround();
    }
}
