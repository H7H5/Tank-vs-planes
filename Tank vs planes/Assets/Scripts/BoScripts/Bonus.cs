using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private List<Sprite> spritesBonus = new List<Sprite>();
    public AudioClip curentAudioclip;
    [SerializeField] private AudioClip upgrade;
    [SerializeField] private AudioClip speed_up;
    [SerializeField] private AudioClip gun_power_up;
    [SerializeField] private AudioClip power_up;
    [SerializeField] private AudioClip shield_up;
    [SerializeField] private SpriteRenderer sprite;
    public int id = 0;     
    void Start()
    {
        sprite.sprite = spritesBonus[id];
        SetCurentAudio();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void SetCurentAudio()
    {
        if(id == 0)
        {
            curentAudioclip = power_up;
        }
        else if (id == 1)
        {
            curentAudioclip = shield_up;
        }
        else if (id == 2)
        {
            curentAudioclip = speed_up;
        }
        else if (id >=3 && id <=5)
        {
            curentAudioclip = gun_power_up;
        }
        else
        {
            curentAudioclip = upgrade;
        }
    }
}
