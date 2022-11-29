using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NuclearCount : MonoBehaviour
{

    public List<GameObject> imagesNuclearIcons;
    public int countActivNuclearIcons;
    public GameObject prefabNuclear;
    public GameObject gameObjectNuclearBG;

    public void CountActivNuclearIcon()
    {
        countActivNuclearIcons = 0;

        foreach (GameObject nuclearIcon in imagesNuclearIcons)
        {
            if (nuclearIcon.activeInHierarchy)
            {
                countActivNuclearIcons++;
            }
        }
    }

    public void NuclearIconsIncreaseCount()
    {
        CountActivNuclearIcon();

        if (countActivNuclearIcons < imagesNuclearIcons.Count)
        {
            countActivNuclearIcons++;

            for (int i = 0; i < countActivNuclearIcons; i++)
            {
                imagesNuclearIcons[i].SetActive(true);
            }
        }
    }

    public void NuclearActivate()
    {
        CountActivNuclearIcon();

        if (countActivNuclearIcons > 0)
        {
            NuclearBackGroundEffects();
            NuclearIconsDecreaseCount();
        }
    }

    private void NuclearBackGroundEffects()
    {
        GameObject nuclear = Instantiate(prefabNuclear, gameObjectNuclearBG.transform.position, Quaternion.identity) as GameObject;
        nuclear.transform.parent = gameObjectNuclearBG.transform;
    }

    public void NuclearIconsDecreaseCount()
    {
        countActivNuclearIcons--;

        for (int i = imagesNuclearIcons.Count; i > 0; i--)
        {
            if (imagesNuclearIcons[i - 1].activeInHierarchy)
            {
                imagesNuclearIcons[i - 1].SetActive(false);
                break;
            }
        }
    }
}
