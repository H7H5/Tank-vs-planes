using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float offset;
    [SerializeField] private List<Sprite> spritesGun = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteGun;
    private int curentGun = 0;     //загружать из БД
    private void Awake()
    {
        spriteGun.sprite = spritesGun[curentGun];
    }
    void Update()
    {
        Vector3 diferense = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diferense.y, diferense.x) * Mathf.Rad2Deg;
        if (diferense.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
    }

    public void NextSpriteGun()
    {
        if (curentGun < spritesGun.Count-1)
        {
            curentGun++;
        }
        else
        {
            curentGun = spritesGun.Count-1;
        }
        spriteGun.sprite = spritesGun[curentGun];
    }


}
