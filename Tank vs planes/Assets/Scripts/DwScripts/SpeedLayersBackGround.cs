using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLayersBackGround : MonoBehaviour
{
    public float SetSpeed(LayerBackGround speedElement)
    {
        float speed;
        switch (speedElement)
        {
            case LayerBackGround.Ground:
                speed = -4f;
                break;
            case LayerBackGround.BackGround:
                speed = -2f;
                break;
            case LayerBackGround.BehindBackGround:
                speed = -1f;
                break;
            case LayerBackGround.Sky:
                speed = -0.5f;
                break;
            default:
                speed = 0f;
                break;
        }
        return speed;
    }
}
