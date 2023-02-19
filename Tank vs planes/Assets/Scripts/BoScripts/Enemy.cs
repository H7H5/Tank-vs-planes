using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private Vector3 vector;
    private float movementSpeed = 0f;
    [SerializeField] private int points = 0;
    private void Awake()
    {
        Init(true);
    }
    public void Init(bool direction)
    {
        movementSpeed = Random.Range(4.0f, 10.0f);
        if (direction)
        {
            vector = Vector3.right;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            vector = Vector3.left;
        }
       
    }
    void Update()
    {
        transform.Translate(vector * Time.deltaTime * movementSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("border"))
        {
            EnemyPool.Instance.DeleteEnemy(gameObject);
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
   
