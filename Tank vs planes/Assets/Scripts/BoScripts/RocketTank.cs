using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTank : MonoBehaviour
{
    private float movementSpeed = 11.0f;
    public int damage = 150;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("border"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
    
}
