using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementsController : MonoBehaviour
{
    public ElementBackGround elementBackGround;
    public GameObject prefabScriptableObject;
    private GameObject prefabCouple;


    public ElementBackGround[] elementScriptable;
    private List<GameObject> prefabsSceneElements = new List<GameObject>();


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

    private void Start()
    {
        moveElementBackGround = backGround.GetComponent<MoveElementBackGround>();

        CreateAndInstantiatePrefab();
    }

    private void FixedUpdate()
    {
        CheckCreationChanceLightHouse();

        CheckCreationChance(prefabsSceneElements[0]);
    }

    private void CreateAndInstantiatePrefab()
    {
        GameObject prefab = Instantiate(prefabScriptableObject);

        PrefabElementProperties scriptPrefabCouple = prefab.GetComponent<PrefabElementProperties>();
        scriptPrefabCouple.namePrefab = elementScriptable[0].nameElement;
        elementScriptable[0].SetBackGroundGameObject(elementScriptable[0].backGroundGameObjects);
        scriptPrefabCouple.elementBackGround = elementScriptable[0].backGround;
        scriptPrefabCouple.moveElementBackGround = elementScriptable[0].backGround.GetComponent<MoveElementBackGround>();
        scriptPrefabCouple.borderCheck = elementScriptable[0].borderCheck;
        scriptPrefabCouple.spawnChance = elementScriptable[0].spawnChance;
        scriptPrefabCouple.spawnCoordinates = elementScriptable[0].spawnCoordinates;
        scriptPrefabCouple.beforeNuclear = elementScriptable[0].beforeNuclear;

        prefab.GetComponent<SpriteRenderer>().sprite = elementScriptable[0].beforeNuclear;
        prefab.GetComponent<NuclearEffects>().spriteAfterNuclear = elementScriptable[0].afterNuclear;

        prefabsSceneElements.Add(prefab);
    }

    private void CheckCreationChance(GameObject prefab)
    {
        PrefabElementProperties scriptPrefab = prefab.GetComponent<PrefabElementProperties>();
        MoveElementBackGround scriptBG = scriptPrefab.elementBackGround.GetComponent<MoveElementBackGround>();
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

    private void InstantiatePrefab(float spawnChance, GameObject prefab, GameObject moveElement, Vector2 spawnCoordinates)
    {
        if (RandomFloatForPercents() < spawnChance)
        {
            GameObject gameObjectInstantiated = Instantiate(prefab, new Vector2(0, 0), Quaternion.identity) as GameObject;
            gameObjectInstantiated.transform.parent = moveElement.transform;
            gameObjectInstantiated.transform.localPosition = spawnCoordinates;
            gameObjectInstantiated.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<PrefabElementProperties>().beforeNuclear;
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
