using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float offset = -90;
    [SerializeField] private List<Sprite> spritesGun = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteGun;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject bullet;
    private int curentGun = 0;     //загружать из БД


    private float timeRtwShots;
    public float startTimeRtwShots;
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
        if(timeRtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                timeRtwShots = startTimeRtwShots;
            }
        }
        else
        {
            timeRtwShots -= Time.deltaTime; 
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
