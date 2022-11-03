using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.001f;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float StartX = transform.position.x;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 EndPoint = new Vector3(worldMousePosition.x, transform.position.y, 0f);
        transform.position = Vector3.Lerp(transform.position, EndPoint, (Time.deltaTime * Speed)/4);
        SetAnimation(StartX, transform.position.x);
    }

    private void SetAnimation(float StartX, float EndX)
    {
        float deltaX = Mathf.Abs(StartX - EndX);
        if(StartX > EndX)
        {
            if (deltaX < 0.01f)
            {
                animator.SetInteger("direction", 0);
            }
            else
            {
                animator.SetInteger("direction", -1);
            }
        }
        else
        {
            if (deltaX < 0.1f)
            {
                animator.SetInteger("direction", 0);
            }
            else
            {
                animator.SetInteger("direction", 1);
            }
        }
    }
}
