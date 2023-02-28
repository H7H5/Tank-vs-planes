using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    private float offset = -90;

    private float offsetG = -70;

    [SerializeField] GameObject gun;


    private float minY = -3.7f;
    private float maxY = 4.8f;

    private float minGun = -83f;
    private float maxGun = -18f;
    private float angle;

    float rotateZ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diferense = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (diferense.y > 0)
        {
            rotateZ = Mathf.Atan2(0, diferense.x) * Mathf.Rad2Deg;

        }
        else
        {
            rotateZ = Mathf.Atan2(diferense.y, diferense.x) * Mathf.Rad2Deg;
            

        }


        transform.rotation = Quaternion.Euler(0f,  rotateZ + offset, 0f);
        UpdateGun();
    }

    void UpdateGun()
    {
        Vector3 diferense = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float y = Clamp(diferense.y, minY, maxY);
        angle = Map(y, minY, maxY, minGun, maxGun);
        Vector3 vector3 = new Vector3(0f, rotateZ + 180f, angle - offsetG);
        gun.transform.rotation = Quaternion.Euler(vector3);

    }


    private float Clamp(float x, float min, float max)
    {
        if (x < min)
        {
            return min;
        }
        else if (x > max)
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
