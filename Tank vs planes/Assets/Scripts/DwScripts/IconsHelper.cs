using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsHelper : MonoBehaviour
{
    public List<GameObject> imagesIcons;
    public int countActivIcons;
    public int maxCountActivIcons = 4;

    public GameObject MegaLaserAction;

    private void Start()
    {
        CountActivIcons();
    }

    public void CountActivIcons()
    {
        countActivIcons = 0;

        foreach (GameObject icon in imagesIcons)
        {
            if (icon.activeInHierarchy)
            {
                countActivIcons++;
            }
        }
    }

    public void CountIncreaseIcons()
    {
        if (countActivIcons < imagesIcons.Count)
        {
            countActivIcons++;

            for (int i = 0; i < countActivIcons; i++)
            {
                imagesIcons[i].SetActive(true);
            }
        }

        if(countActivIcons == maxCountActivIcons)
        {
            MegaLaserActivate();
        }
    }

    public void CountDecreaseIcons()
    {
        if (countActivIcons > 0)
        {
            countActivIcons--;

            for (int i = imagesIcons.Count; i > 0; i--)
            {
                if (imagesIcons[i - 1].activeInHierarchy)
                {
                    imagesIcons[i - 1].SetActive(false);
                    break;
                }
            }
        }
    }

    public void MegaLaserActivate()
    {
        countActivIcons = 0;

        foreach (GameObject icon in imagesIcons)
        {
            icon.SetActive(false);
        }

        MegaLaserAction.SetActive(true);
    }
}
