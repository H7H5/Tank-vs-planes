using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsHelper : MonoBehaviour
{
    public List<GameObject> imagesIcons;
    public int countActivIcons;

    private void Start()
    {
        CountActivIcons();
    }

    public void CountActivIcons()
    {
        countActivIcons = 0;

        foreach (GameObject nuclearIcon in imagesIcons)
        {
            if (nuclearIcon.activeInHierarchy)
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
}
