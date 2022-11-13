using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NuclearCount : MonoBehaviour
{

    public List<GameObject> imagesNuclearIcons;
    public int countActivNuclearIcons;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

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

    public void NuclearIconsDecreaseCount()
    {
        CountActivNuclearIcon();

        if(countActivNuclearIcons > 0)
        {
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
}