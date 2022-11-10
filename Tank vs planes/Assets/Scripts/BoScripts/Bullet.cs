using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float movementSpeed = 15.0f;
    public int damage = 50;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> spritesBullet = new List<Sprite>();

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("border"))
        {
            Destroy(gameObject);
        }
        
    }
    public void SetDamage(int level)
    {
        damage += (level * 10);
        if (level < spritesBullet.Count)
        {
            spriteRenderer.sprite = spritesBullet[level];
        }
        else
        {
            spriteRenderer.sprite = spritesBullet[spritesBullet.Count-1];
        }
    }
}
