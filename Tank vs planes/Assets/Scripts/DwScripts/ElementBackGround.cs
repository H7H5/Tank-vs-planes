using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element Back Ground", menuName = "Element Back Ground")]
public class ElementBackGround : ScriptableObject
{
    public string nameElement;

    [HideInInspector]
    public GameObject backGround;
    [HideInInspector]
    public float speed;

    public BackGroundGameObjects backGroundGameObjects;

    public float borderCheck;
    [SerializeField]
    [Range(0f, 100f)]
    public float spawnChance;
    public Vector2 spawnCoordinates;

    public Sprite beforeNuclear;
    public Sprite afterNuclear;

    public enum BackGroundGameObjects
    {
        Ground,
        BackGround,
        BehindBackGround,
        Sky
    }

    public void SetSpeedElements(BackGroundGameObjects speedElement)
    {
        switch (speedElement)
        {
            case BackGroundGameObjects.Ground:
                speed = -4f;
                break;
            case BackGroundGameObjects.BackGround:
                speed = -2f;
                break;
            case BackGroundGameObjects.BehindBackGround:
                speed = -1f;
                break;
            case BackGroundGameObjects.Sky:
                speed = -0.5f;
                break;
            default:
                speed = 0f;
                break;
        }
    }

    public void SetBackGroundGameObject (BackGroundGameObjects backGroundGameObjects)
    {
        GameObject backGrounds = GameObject.Find("BackGrounds");
        switch (backGroundGameObjects)
        {
            case BackGroundGameObjects.Ground:
                backGround = backGrounds.transform.GetChild(0).gameObject;
                break;
            case BackGroundGameObjects.BackGround:
                backGround = backGrounds.transform.GetChild(1).gameObject;
                break;
            case BackGroundGameObjects.BehindBackGround:
                backGround = backGrounds.transform.GetChild(2).gameObject;
                break;
            case BackGroundGameObjects.Sky:
                backGround = backGrounds.transform.GetChild(3).gameObject;
                break;
            default:
                backGround = backGrounds.transform.GetChild(0).gameObject;
                break;
        }
    }
}
