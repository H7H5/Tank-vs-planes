using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsController : MonoBehaviour
{
    public static IconsController Instance;
    public NuclearCount NuclearCount;
    public IconsHelper iconsMegaLaser;

    public GameObject MegaLaserAction;

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

    public void NuclearExplosion()
    {
        NuclearCount.NuclearIconsDecreaseCount();

        NuclearEventManager.SendNuclearExplosion();
    }

    public void MegaLaserCountIncrease()
    {
        iconsMegaLaser.CountIncreaseIcons();
    }

    public void MegaLaserCountDecrease()
    {
        iconsMegaLaser.CountDecreaseIcons();
        iconsMegaLaser.CountDecreaseIcons();
        iconsMegaLaser.CountDecreaseIcons();
        iconsMegaLaser.CountDecreaseIcons();

        MegaLaserAction.SetActive(true);
    }
}
