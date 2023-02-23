using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabElementProperties : MonoBehaviour
{
    public string namePrefab;

    public GameObject elementBackGround;
    public MoveElementBackGround moveElementBackGround;
    public float speed;
    public float borderCheck;
    [SerializeField]
    [Range(0f, 100f)]
    public float spawnChance;
    public Vector2 spawnCoordinates;

    public Sprite beforeNuclear;

    public bool isExist = false;
}
