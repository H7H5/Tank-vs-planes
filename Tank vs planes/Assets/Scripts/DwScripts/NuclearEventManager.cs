using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NuclearEventManager : MonoBehaviour
{
    //public static event Action OnNuclearExplosion;

    public static UnityEvent OnNuclearExplosion = new UnityEvent();

    public static void SendNuclearExplosion()
    {
        //if (OnNuclearExplosion != null)
        //{
        //    OnNuclearExplosion.Invoke();
        //}

        OnNuclearExplosion.Invoke();
    }
}
