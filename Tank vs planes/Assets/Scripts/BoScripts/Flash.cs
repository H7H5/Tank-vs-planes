using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float speed = 0.1f;
    [SerializeField] private GameObject target;
    public List<Vector3> points = new List<Vector3>();
    private int currentPoint = 0;
    public int step = 0; 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(step < 18)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (step < 36)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (step < 54)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (step < 72)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else
        {
            spriteRenderer.sprite = sprites[4];
        }

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint], speed);
        float distantion = Vector3.Distance(gameObject.transform.position, points[currentPoint]);
        if (distantion< 0.02f)
        {
            currentPoint++;
            if(currentPoint >= points.Count)
            {
                Destroy(gameObject);
            }
        }
        

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
