using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NuclearEventManager : MonoBehaviour
{
    public static UnityEvent OnNuclearExplosion = new UnityEvent();
    public static UnityEvent OnStopMoveEnvironment = new UnityEvent();
    public static UnityEvent OnStartMoveEnvironment = new UnityEvent();

    public static void SendNuclearExplosion()
    {
        OnNuclearExplosion.Invoke();
    }

    public static void SendStopMoveEnvironment()
    {
        OnStopMoveEnvironment.Invoke();
    }

    public static void SendStartMoveEnvironment()
    {
        OnStartMoveEnvironment.Invoke();
    }
}
