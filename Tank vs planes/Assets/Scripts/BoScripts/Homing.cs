using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    [SerializeField] private List<Sprite> spritesHoming = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int level = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }

    public void UpdeteHoming()
    {
        level++;
        if(level > 3)
        {
            level = 3;
        }
        spriteRenderer.sprite = spritesHoming[level-1];
    }
}
