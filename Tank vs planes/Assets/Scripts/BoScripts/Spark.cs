using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> spritesSpark = new List<Sprite>();
    private float movementSpeed;
    private Vector3 direction;
    float step;
    void Start()
    {
        spriteRenderer.sprite = spritesSpark[Random.Range(0, spritesSpark.Count)];
        movementSpeed = Random.Range(0.5f, 1.5f);
        step = movementSpeed * Time.deltaTime; // calculate distance to move
        direction = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
        Invoke("SpawnObject", 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }

    void SpawnObject()
    {
        Destroy(gameObject);
    }
}
