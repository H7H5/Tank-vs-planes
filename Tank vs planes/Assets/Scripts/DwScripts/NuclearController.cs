using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearController : MonoBehaviour
{
    public NuclearCount nuclearCount;
    public GameObject nuclearBG;

    public void NuclearActivateSelf ()
    {
        if (nuclearCount.countActivNuclearIcons > 0)
        {
            nuclearBG.SetActive(true);
        }
    }
    public void NuclearOff()
    {
        gameObject.SetActive(false);
    }
}
