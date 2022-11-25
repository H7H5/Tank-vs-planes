using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuidanceMissile : MonoBehaviour
{
    private float offset = -90;
    private float movementSpeed = 10.0f;
    [SerializeField] private List<Sprite> spritesMissile = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float decisionPoint = 0f;
    private float speedRotation = 200f;
    private Transform target;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 diferense = target.position - transform.position;
            float rotateZ = Mathf.Atan2(diferense.y, diferense.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speedRotation * Time.deltaTime);
        }
        else
        {
            if (transform.position.y>decisionPoint)
            {
                FindTarget();
            }
        }
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }
    private void SelectImage(float rotateZ)
    {
        int number = 0;
        if (rotateZ >= -15)
        {
            number = Mathf.Abs((int)(rotateZ / 15));
        }
        else
        {
            number = spritesMissile.Count-1-(Mathf.Abs((int)(rotateZ / 20)));
        }
        spriteRenderer.sprite = spritesMissile[number];

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
    private void FindTarget()
    {
        try{
            target = EnemyPool.Instance.GetEnemy();
        }
        catch (Exception e)
        {

        }
    }
}
