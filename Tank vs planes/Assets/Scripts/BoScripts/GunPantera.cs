using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPantera : MonoBehaviour
{
    [SerializeField] GameObject tower;

    private float offset = -70;

    private float minY = -3.7f;
    private float maxY = 4.8f;

    private float minGun = -83f;
    private float maxGun = -18f;
    private float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diferense = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float y = Clamp(diferense.y, minY, maxY);
        angle = Map(y, minY, maxY, minGun, maxGun);

        Vector3 vector3 = new Vector3(0f, -90f, angle - offset);
        transform.rotation = Quaternion.Euler(vector3);

    }


    private float Clamp (float x, float min, float max)
    {
        if (x<min)
        {
            return min;
        }else if (x > max)
        {
            return max;
        }
        else
        {
            return x;
        }
    }
    public static float Map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }

}
