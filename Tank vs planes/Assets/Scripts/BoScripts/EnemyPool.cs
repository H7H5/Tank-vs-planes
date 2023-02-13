using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] Transform leftSpawnPoint;
    [SerializeField] Transform RightSpawnPoint;
    public static EnemyPool Instance;
    public List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        StartCoroutine(TestCoroutine());
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


    IEnumerator TestCoroutine()
    {
        while (true)
        {
            float delay = Random.Range(0.1f, 1.5f);
            CreateEnemy();
            yield return new WaitForSeconds(delay);
        }
    }
    private void CreateEnemy()
    {
        bool direction;
        int rand = Random.Range(0, 10);
        direction = rand < 5 ? true : false; //true = leftSpawnPoint
        GameObject enemy;
        float y = Random.Range(leftSpawnPoint.position.y, RightSpawnPoint.position.y);
        int numberEnemy = Random.Range(0, enemyPrefabs.Count);
        //int numberEnemy = 8;
        if (direction)
        {
             Vector3 startPosition = new Vector3(leftSpawnPoint.position.x, y, leftSpawnPoint.position.z);
             enemy = Instantiate(enemyPrefabs[numberEnemy], startPosition, leftSpawnPoint.transform.rotation);
        }
        else
        {
            Vector3 startPosition = new Vector3(RightSpawnPoint.position.x, y, RightSpawnPoint.position.z);
            enemy = Instantiate(enemyPrefabs[numberEnemy], startPosition, RightSpawnPoint.transform.rotation);
        }
        enemy.GetComponent<Enemy>().Init(direction);
        enemies.Add(enemy);


    }
    public void DeleteEnemy(GameObject enemy)
    {
        for (int i = 0; i < enemies.Count ; i++)
        {
            if (enemy.GetInstanceID() == enemies[i].GetInstanceID())
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
        }
    }
}

