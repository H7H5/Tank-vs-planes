using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearEffects : MonoBehaviour
{
    public Sprite spriteAfterNuclear;

    void Start()
    {
        NuclearEventManager.OnNuclearExplosion.AddListener(NuclearExplosion);
    }

    public void NuclearExplosion()
    {
        transform.GetComponent<SpriteRenderer>().sprite = spriteAfterNuclear;
    }
}
