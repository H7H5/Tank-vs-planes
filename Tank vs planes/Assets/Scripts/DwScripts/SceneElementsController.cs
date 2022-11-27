using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElementsController : MonoBehaviour
{
    public GameObject prefabLightHouse;

    private void Start()
    {
        Instantiate(prefabLightHouse, new Vector2(0, 0.8f), Quaternion.identity);
    }
}
