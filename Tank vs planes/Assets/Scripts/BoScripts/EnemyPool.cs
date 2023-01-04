using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    public List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetEnemy()
    {
        if (enemies.Count > 0)
        {
            return enemies[0].transform;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetEnemyLighting(Transform shotTransform)
    {
        float dist = 100000000000f;
        GameObject target = null;
        for (int i = 0; i < enemies.Count; i++)
        {
            float dist1 = Vector3.Distance(enemies[i].transform.position, shotTransform.position);
            Debug.Log(dist1);
            if (dist1 < dist)
            {
               
                dist = dist1;
                target = enemies[i];
            }
        }
        return target;
    }
    public bool IsEnemy()
    {
        if (enemies.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
