using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerBackGround : MonoBehaviour
{
    public int level = 0;
    public int maxLevel = 2;

    public GameObject[] grounds;
    public GameObject[] backGrounds;
    public GameObject[] behindBackGrounds;
    public GameObject[] skies;

    public Sprite[] groundSprites;
    public Sprite[] backGroundSprites;
    public Sprite[] behindBackGroundSprites;
    public Sprite[] skySprites;

    public void ChangeSpriteBackGround()
    {
        if(level < 0)
        {
            level = 0;
        }

        if(level > maxLevel)
        {
            level = maxLevel - 1;
        }

        foreach (var ground in grounds)
        {
            ground.GetComponent<SpriteRenderer>().sprite = groundSprites[level];
        }

        foreach (var backGround in backGrounds)
        {
            backGround.GetComponent<SpriteRenderer>().sprite = backGroundSprites[level];
        }

        foreach (var behindBackGround in behindBackGrounds)
        {
            behindBackGround.GetComponent<SpriteRenderer>().sprite = behindBackGroundSprites[level];
        }

        foreach (var sky in skies)
        {
            sky.GetComponent<SpriteRenderer>().sprite = skySprites[level];
        }
    }
}
