using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketPlace : MonoBehaviour
{
    [SerializeField] private List<GameObject> places = new List<GameObject>();
    [SerializeField] private GameObject rocketPod ;
    private int level = 0;


    public void UpdeteRocket()
    {
        level++;
        if (level > 3)
        {
            level = 3;
        }
        SetRocketPods();
    }

    private void SetRocketPods()
    {
        DeleteRocketPods();
        switch (level)
        {
            case 1:
                CreateRocketPod(places[0]);
                break;
            case 2:
                CreateRocketPod(places[3]);
                CreateRocketPod(places[4]);
                break;
            case 3:
                CreateRocketPod(places[0]);
                CreateRocketPod(places[1]);
                CreateRocketPod(places[2]);
                break;

        }
    }

    private void CreateRocketPod(GameObject place)
    {
        Instantiate(rocketPod, place.transform);
    }
    private void DeleteRocketPods()
    {
        for (int i = 0; i < places.Count; i++)
        {
            if (places[i].transform.childCount>0)
            {
                Destroy(places[i].transform.GetChild(0).gameObject);
            }
        }
    }

}
