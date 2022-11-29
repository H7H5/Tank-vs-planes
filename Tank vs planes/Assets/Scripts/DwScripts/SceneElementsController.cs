using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementsController : MonoBehaviour
{
    public GameObject prefabLightHouse;
    public GameObject sceneElements;
    public GameObject backGround;

    [SerializeField]
    [Range(0f, 100f)]
    private float spawnChancePercents;

    public Vector2 spawnCoordinates;

    private float RandomFloatForPercents()
    {
        return Random.Range(0f, 100f);
    }

    public void InstantiateLightHouse()
    {
        if(RandomFloatForPercents() < spawnChancePercents)
        {
            GameObject lightHous = Instantiate(prefabLightHouse, new Vector2(0, 0), Quaternion.identity) as GameObject;
            lightHous.transform.parent = backGround.transform;
            lightHous.transform.localPosition = spawnCoordinates;
        }
        
    }
}
