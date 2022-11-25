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
}
