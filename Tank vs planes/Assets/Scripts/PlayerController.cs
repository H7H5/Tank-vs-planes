using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.001f;
    private void FixedUpdate()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 EndPoint = new Vector3(worldMousePosition.x, transform.position.y, 0f);

        transform.position = Vector3.Lerp(transform.position, EndPoint, (Time.deltaTime * Speed)/4);
    }
}
