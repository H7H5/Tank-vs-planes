using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementsController : SpeedLayersBackGround
{
    public ElementBackGround elementBackGround;
    public GameObject prefabScriptableObject;

    public ElementBackGround[] elementsScriptable;
    private List<GameObject> prefabsSceneElements = new List<GameObject>();

    private GameObject sceneElements;

    private void Start()
    {
        sceneElements = GameObject.Find("SceneElements");

        GameObject prefabsElementScene = GameObject.Find("PrefabsElementScene");

        foreach (ElementBackGround element in elementsScriptable)
        {

            CreateAndInstantiatePrefab(element, prefabsElementScene);
        }
    }

    private void FixedUpdate()
    {
        foreach (GameObject prefab in prefabsSceneElements)
        {
            CheckCreationChance(prefab);
        }
    }

    private void CreateAndInstantiatePrefab(ElementBackGround element, GameObject prefabsElementScene)
    {
        GameObject prefab = Instantiate(prefabScriptableObject);
        prefab.transform.SetParent(prefabsElementScene.transform);

        PrefabElementProperties scriptPrefabCouple = prefab.GetComponent<PrefabElementProperties>();
        scriptPrefabCouple.namePrefab = element.nameElement;
        //element.SetBackGroundGameObject(element.layerBackGround);
        scriptPrefabCouple.elementBackGround = SetBackGroundGameObject(element.layerBackGround);
        //element.SetSpeedElements(element.backGroundGameObjects);
        scriptPrefabCouple.speed = SetSpeed(element.layerBackGround);
        //scriptPrefabCouple.moveElementBackGround = element.backGround.GetComponent<MoveElementBackGround>();
        scriptPrefabCouple.moveElementBackGround = scriptPrefabCouple.GetComponent<MoveElementBackGround>();
        scriptPrefabCouple.borderCheck = element.borderCheck;
        scriptPrefabCouple.spawnChance = element.spawnChance;
        scriptPrefabCouple.spawnCoordinates = element.spawnCoordinates;
        scriptPrefabCouple.beforeNuclear = element.beforeNuclear;

        prefab.GetComponent<SpriteRenderer>().sprite = element.beforeNuclear;
        prefab.GetComponent<NuclearEffects>().spriteAfterNuclear = element.afterNuclear;

        prefabsSceneElements.Add(prefab);
    }

    private void CheckCreationChance(GameObject prefab)
    {
        PrefabElementProperties scriptPrefab = prefab.GetComponent<PrefabElementProperties>();
        MoveElementBackGround scriptBG = scriptPrefab.elementBackGround.GetComponent<MoveElementBackGround>();
        if (scriptBG.GetPosX() > 0 && scriptBG.GetPosX() < scriptPrefab.borderCheck && scriptPrefab.isExist == false)
        {
            scriptPrefab.isExist = true;
            InstantiatePrefab(scriptPrefab.spawnChance, prefab, scriptPrefab.elementBackGround, scriptPrefab.spawnCoordinates, scriptPrefab.speed);
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

    private void InstantiatePrefab(float spawnChance, GameObject prefab, GameObject moveElement, Vector2 spawnCoordinates, float speed)
    {
        if (RandomFloatForPercents() < spawnChance)
        {
            GameObject gameObjectInstantiated = Instantiate(prefab, new Vector2(0, 0), Quaternion.identity) as GameObject;
            gameObjectInstantiated.transform.parent = moveElement.transform;
            gameObjectInstantiated.transform.localPosition = spawnCoordinates;
            gameObjectInstantiated.GetComponent<MoveSceneElements>().SetSpeedSceneElement(speed);
            gameObjectInstantiated.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<PrefabElementProperties>().beforeNuclear;
            gameObjectInstantiated.transform.SetParent(sceneElements.transform);
        }
    }

    public GameObject SetBackGroundGameObject(LayerBackGround backGroundGameObjects)
    {
        GameObject backGround;
        GameObject backGrounds = GameObject.Find("BackGrounds");
        switch (backGroundGameObjects)
        {
            case LayerBackGround.Ground:
                backGround = backGrounds.transform.GetChild(0).gameObject;
                break;
            case LayerBackGround.BackGround:
                backGround = backGrounds.transform.GetChild(1).gameObject;
                break;
            case LayerBackGround.BehindBackGround:
                backGround = backGrounds.transform.GetChild(2).gameObject;
                break;
            case LayerBackGround.Sky:
                backGround = backGrounds.transform.GetChild(3).gameObject;
                break;
            default:
                backGround = backGrounds.transform.GetChild(0).gameObject;
                break;
        }
                return backGround;
    }
}
