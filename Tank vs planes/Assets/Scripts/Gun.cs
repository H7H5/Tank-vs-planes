using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float offset;
    void Update()
    {
        Vector3 diferense = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diferense.y, diferense.x) * Mathf.Rad2Deg;
        if (diferense.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
    }
}
