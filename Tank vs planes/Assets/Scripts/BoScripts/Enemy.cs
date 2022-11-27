using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementSpeed = 3.0f;
    //public int damage = 50;
    //[SerializeField] SpriteRenderer spriteRenderer;
    //[SerializeField] private List<Sprite> spritesBullet = new List<Sprite>();

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("border"))
        {
            //Destroy(gameObject);
        }

    }
}
   
