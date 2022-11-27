using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneElements : MonoBehaviour
{
    [SerializeField]
    float speed;
    private float pos_x;
    private float pos_y;
    private float pos_x_destroy = - 20f;
    void Start()
    {
        pos_x = GetComponent<SpriteRenderer>().transform.position.x;
        pos_y = GetComponent<SpriteRenderer>().transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(pos_x < pos_x_destroy)
        {
            Destroy(gameObject);
        }
        pos_x += speed * Time.deltaTime;
        transform.position = new Vector3(pos_x, pos_y, 0);
    }
}
