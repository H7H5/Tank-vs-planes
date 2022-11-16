using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsController : MonoBehaviour
{
    public static IconsController Instance;
    public NuclearCount NuclearCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void NuclearCountIncrease()
    {
        NuclearCount.NuclearIconsIncreaseCount();
    }

    public void TestIconsController()
    {
        Debug.Log("TestIconsController()");
    }
}
