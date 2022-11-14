using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color m_NewColor;
    private float r = 1f;
    private float g = 1f;
    private float b = 1f;
    private float a = 1f;
    private bool flag = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        spriteRenderer.color = new Color(r, g, b, a);
        showColor();
    }

    private void showColor()
    {
        if (flag)
        {
            g -= 0.1f;
            if (g <= 0)
            {
                g = 0;
                flag = false;
            }
        }
        else
        {
            g += 0.1f;
            if (g >= 1)
            {
                g = 1;
                flag = true;
            }
        }
        b = g;
        a -= 0.007f;
        if(a <= 0)
        {
            Destroy(gameObject);
        }
       
    }




}
