using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float offset = -90;
    private int LevelCountBulet = 1; //загружать из БД
    [SerializeField] private List<Sprite> spritesGun = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteGun;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject bullet;
    private int curentGun = 0;     //загружать из БД
    private int powerGun = 0;


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
                Shot();
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
        LevelCountBulet++;
        if (LevelCountBulet >= 6) LevelCountBulet = 5;
    }

    private void Shot()
    {
        switch (LevelCountBulet)
        {
            case 1:
                CreateBullet(0);
                break;
            case 2:
                CreateBullet(10f);
                CreateBullet(-10f);
                break;
            case 3:
                CreateBullet(10f);
                CreateBullet(-10f);
                CreateBullet(0f);
                break;
            case 4:
                CreateBullet(10f);
                CreateBullet(-10f);
                CreateBullet(20f);
                CreateBullet(-20f);
                break;
            case 5:
                CreateBullet(0f);
                CreateBullet(10f);
                CreateBullet(-10f);
                CreateBullet(25f);
                CreateBullet(-25f);
                break;
        }
       
       
    }

    private GameObject CreateBullet(float angle)
    {
        GameObject shot = Instantiate(bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        shot.transform.Rotate(SpawnPoint.transform.rotation.x, SpawnPoint.transform.rotation.y, SpawnPoint.transform.rotation.z + angle);
        shot.GetComponent<Bullet>().SetDamage(powerGun);
        return shot;
    }

    public void GunPowerUP()
    {
        powerGun += 1;
    }
}
