using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementsController : MonoBehaviour
{
    public GameObject prefabLightHouse;
    public GameObject backGround;
    private MoveElementBackGround moveElementBackGround;
    private float borderCheckLightHouse = 17f;

    [SerializeField]
    [Range(0f, 100f)]
    private float lightHouseSpawnChance;
    private bool isLightHouse = false;

    public Vector2 spawnCoordinates;

    private void Start()
    {
        moveElementBackGround = backGround.GetComponent<MoveElementBackGround>();
    }

    private void Update()
    {
        CheckCreationChanceLightHouse();
    }

    private float RandomFloatForPercents()
    {
        return Random.Range(0f, 100f);
    }

    public void InstantiateLightHouse()
    {
        if(RandomFloatForPercents() < lightHouseSpawnChance)
        {
            GameObject lightHous = Instantiate(prefabLightHouse, new Vector2(0, 0), Quaternion.identity) as GameObject;
            lightHous.transform.parent = backGround.transform;
            lightHous.transform.localPosition = spawnCoordinates;
        }
    }

    private void CheckCreationChanceLightHouse()
    {
        if (moveElementBackGround.GetPosX() > 0 && moveElementBackGround.GetPosX() < borderCheckLightHouse && isLightHouse == false)
        {
            isLightHouse = true;
            InstantiateLightHouse();
        }

        if (isLightHouse == true && moveElementBackGround.GetPosX() > borderCheckLightHouse)
        {
            isLightHouse = false;
        }
    }
}
