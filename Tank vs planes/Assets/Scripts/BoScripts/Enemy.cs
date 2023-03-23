using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private Vector3 vector;
    private float movementSpeed = 10f;
    [SerializeField] private int points = 0;
    private bool direction = true;
    private void Awake()
    {
        Init(direction);
    }
    public void Init(bool direction)
    {
        movementSpeed = Random.Range(4.0f, 10.0f);
        this.direction = direction;

    }
    void Update()
    {
        if (direction)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1f, 0f, 0f) * movementSpeed;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1f, 0f, 0f) * movementSpeed;
        }

    }
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("border"))
        {
           // EnemyPool.Instance.DeleteEnemy(gameObject);
            //Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            points -= collision.GetComponent<Bullet>().damage;
            if (points<=0)
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                EnemyPool.Instance.DeleteEnemy(gameObject);
            }
        }

    }
}
   
