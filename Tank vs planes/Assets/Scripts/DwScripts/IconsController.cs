using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsController : MonoBehaviour
{
    public static IconsController Instance;
    public NuclearCount NuclearCount;
    public IconsHelper iconsMegaLaser;

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
        NuclearCount.NuclearActivate();

        NuclearEventManager.SendNuclearExplosion();
    }


    public void StopMoveEnvironment()
    {
        NuclearEventManager.SendStopMoveEnvironment();
    }

    public void StartMoveEnvironment()
    {
        NuclearEventManager.SendStartMoveEnvironment();
    }

    public void MegaLaserCountIncrease()
    {
        iconsMegaLaser.CountIncreaseIcons();
    }
}
