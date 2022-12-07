using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementsController : MonoBehaviour
{
    public ElementBackGround elementBackGround;
    public GameObject prefabScriptableObject;
    private GameObject prefabCouple;

    [Header("LightHouse")]
    public GameObject prefabLightHouse;
    public GameObject backGround;
    private MoveElementBackGround moveElementBackGround;
    private float borderCheckLightHouse = 17f;
    [SerializeField]
    [Range(0f, 100f)]
    private float lightHouseSpawnChance;
    private bool isLightHouse = false;
    public Vector2 lightHouseSpawnCoordinates;

    [Header("CoupleOnBeach")]
    public GameObject prefabCoupleOnBeach;
    public GameObject ground;
    private MoveElementBackGround moveElementGround;
    private float borderCheckCouple = 12f;
    [SerializeField]
    [Range(0f, 100f)]
    private float CoupleSpawnChance;
    private bool isCouple = false;
    public Vector2 CoupleSpawnCoordinates;

    private void Start()
    {
        moveElementBackGround = backGround.GetComponent<MoveElementBackGround>();
        moveElementGround = ground.GetComponent<MoveElementBackGround>();

        //prefabCouple = prefabScriptableObject;
        prefabCouple = Instantiate(prefabCoupleOnBeach);
        PrefabElementProperties scriptPrefabCouple = prefabCouple.GetComponent<PrefabElementProperties>();
        scriptPrefabCouple.namePrefab = elementBackGround.nameElement;
        elementBackGround.SetBackGroundGameObject(elementBackGround.backGroundGameObjects);
        scriptPrefabCouple.elementBackGround = elementBackGround.backGround;
        scriptPrefabCouple.moveElementBackGround = elementBackGround.backGround.GetComponent<MoveElementBackGround>();
        scriptPrefabCouple.borderCheck = elementBackGround.borderCheck;
        scriptPrefabCouple.spawnChance = elementBackGround.spawnChance;
        scriptPrefabCouple.spawnCoordinates = elementBackGround.spawnCoordinates;
        scriptPrefabCouple.beforeNuclear = elementBackGround.beforeNuclear;

        prefabCouple.GetComponent<SpriteRenderer>().sprite = elementBackGround.beforeNuclear;
        prefabCouple.GetComponent<NuclearEffects>().spriteAfterNuclear = elementBackGround.afterNuclear;
    }

    private void Update()
    {
        CheckCreationChanceLightHouse();
        //CheckCreationChanceCouple();
        //CheckCreationChance(moveElementGround, borderCheckCouple, CoupleSpawnChance, prefabCoupleOnBeach, ground, CoupleSpawnCoordinates);
        CheckCreationChance(prefabCouple);
    }

    private void CheckCreationChance(GameObject prefab)
    {
        PrefabElementProperties scriptPrefab = prefab.GetComponent<PrefabElementProperties>();
        MoveElementBackGround scriptBG = scriptPrefab.elementBackGround.GetComponent<MoveElementBackGround>();
        //Debug.Log(scriptPrefab.isExist);
        if (scriptBG.GetPosX() > 0 && scriptBG.GetPosX() < scriptPrefab.borderCheck && scriptPrefab.isExist == false)
        {
            scriptPrefab.isExist = true;
            InstantiatePrefab(scriptPrefab.spawnChance, prefab, scriptPrefab.elementBackGround, scriptPrefab.spawnCoordinates);
        }

        if (scriptPrefab.isExist == true && scriptBG.GetPosX() > scriptPrefab.borderCheck)
        {
            scriptPrefab.isExist = false;
        }
    }

    private float RandomFloatForPercents()
    {
        return Random.Range(0f, 100f);
    }

    public void InstantiatePrefab(float spawnChance, GameObject prefab, GameObject moveElement, Vector2 spawnCoordinates)
    {
        if (RandomFloatForPercents() < spawnChance)
        {
            GameObject gameObjectInstantiated = Instantiate(prefab, new Vector2(0, 0), Quaternion.identity) as GameObject;
            gameObjectInstantiated.transform.parent = moveElement.transform;
            gameObjectInstantiated.transform.localPosition = spawnCoordinates;
            gameObjectInstantiated.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<PrefabElementProperties>().beforeNuclear;
        }
    }

    //private void CheckCreationChance( MoveElementBackGround scriptMoveElement, float borderCheck, float spawnChance, GameObject prefab, GameObject moveElement, Vector2 spawnCoordinates)
    //{
    //    if (scriptMoveElement.GetPosX() > 0 && scriptMoveElement.GetPosX() < borderCheck && prefab.GetComponent<IsExistPrefab>().isExist == false)
    //    {
    //        prefab.GetComponent<IsExistPrefab>().isExist = true;
    //        InstantiatePrefab(spawnChance, prefab, moveElement, spawnCoordinates);
    //    }
    //
    //    if (prefab.GetComponent<IsExistPrefab>().isExist == true && scriptMoveElement.GetPosX() > borderCheck)
    //    {
    //        prefab.GetComponent<IsExistPrefab>().isExist = false;
    //    }
    //}

    private void CheckCreationChanceCouple()
    {
        if (moveElementGround.GetPosX() > 0 && moveElementGround.GetPosX() < borderCheckCouple && isCouple == false)
        {
            isCouple = true;
            InstantiatePrefab(CoupleSpawnChance, prefabCoupleOnBeach, ground, CoupleSpawnCoordinates);
        }

        if (isCouple == true && moveElementGround.GetPosX() > borderCheckCouple)
        {
            isCouple = false;
        }
    }

    public void InstantiateLightHouse()
    {
        if(RandomFloatForPercents() < lightHouseSpawnChance)
        {
            GameObject lightHous = Instantiate(prefabLightHouse, new Vector2(0, 0), Quaternion.identity) as GameObject;
            lightHous.transform.parent = backGround.transform;
            lightHous.transform.localPosition = lightHouseSpawnCoordinates;
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
