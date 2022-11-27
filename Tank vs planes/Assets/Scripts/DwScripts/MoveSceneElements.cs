using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneElements : MonoBehaviour
{
    [SerializeField]
    float speed;
<<<<<<< Dweren
    private float keepSpeed;
=======
>>>>>>> main
    private float pos_x;
    private float pos_y;
    private float pos_x_destroy = - 20f;
    void Start()
    {
<<<<<<< Dweren
        NuclearEventManager.OnStopMoveEnvironment.AddListener(StopMoveBackGround);
        NuclearEventManager.OnStartMoveEnvironment.AddListener(StartMoveBackGround);

=======
>>>>>>> main
        pos_x = GetComponent<SpriteRenderer>().transform.position.x;
        pos_y = GetComponent<SpriteRenderer>().transform.position.y;
    }

    void Update()
    {
        Move();
    }

    public void StopMoveBackGround()
    {
        if (speed != 0)
        {
            keepSpeed = speed;
        }
        speed = 0;
    }

    public void StartMoveBackGround()
    {
        if (speed == 0)
        {
            speed = keepSpeed;
        }
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
