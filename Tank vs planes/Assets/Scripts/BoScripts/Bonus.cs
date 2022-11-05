using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private List<Sprite> spritesBonus = new List<Sprite>();
    [SerializeField] private SpriteRenderer sprite;
    public int id = 0;     
    void Start()
    {
        sprite.sprite = spritesBonus[id];
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hjkhg444444444jghj");
    }
}
