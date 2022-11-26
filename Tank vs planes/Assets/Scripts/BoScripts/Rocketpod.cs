using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketpod : MonoBehaviour
{
    private int level = 1;

    private float[] cooldown = { 0.4f, 0.3f, 0.2f };
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject SpawnPoint;

    private float timeRtwShots;
    public float startTimeRtwShots = 0;
    void Start()
    {
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
        startTimeRtwShots = cooldown[level-1];
    }
    private GameObject Shot()
    {
        GameObject shot = Instantiate(bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        return shot;
    }
}
