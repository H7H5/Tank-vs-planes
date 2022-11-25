using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    [SerializeField] private List<Sprite> spritesHoming = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int level = 0;

    private float[] cooldown = { 0.5f, 0.4f, 0.25f };
    [SerializeField] GameObject bullet;

    private float timeRtwShots;
    public float startTimeRtwShots = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (timeRtwShots <= 0 && startTimeRtwShots > 0)
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

    public void UpdeteHoming()
    {
        level++;
        if(level > 3)
        {
            level = 3;
        }
        spriteRenderer.sprite = spritesHoming[level-1];
        startTimeRtwShots = cooldown[level-1];
    }
    private void Shot()
    {
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
        //shot.transform.Rotate(SpawnPoint.transform.rotation.x, SpawnPoint.transform.rotation.y, SpawnPoint.transform.rotation.z);

    }

 }
