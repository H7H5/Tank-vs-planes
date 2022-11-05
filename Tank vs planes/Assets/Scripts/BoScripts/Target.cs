using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Speed = 10f;
    private void FixedUpdate()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Cursor = new Vector3(worldMousePosition.x, worldMousePosition.y, 0f);

        transform.position = Vector3.Lerp(transform.position, Cursor, Time.deltaTime * Speed);
    }
}
