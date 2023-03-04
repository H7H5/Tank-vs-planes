using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxSpeed = 0.3f;
    private float speed = 0.1f;
    private Animator animator;
    [SerializeField] private Gun gun;
    [SerializeField] private Homing homing;
    [SerializeField] private RocketPlace rocketPlace;
    [SerializeField] private Lightning lightning;
    [SerializeField] private List<Sprite> spritesTank = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteTank;
    [SerializeField] AudioSource audioSource;
    float positionTankX = 0;
    int curentSprite = 0;
    int stepidle = 0;
    [SerializeField] private Caterpillar caterpillar;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        float StartX = transform.position.x;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 EndPoint = new Vector3(worldMousePosition.x, transform.position.y, 0f);
        if (Vector3.Distance(transform.position, EndPoint) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint, speed);
        }
        SetAnimation();

    }
   

    private void SetAnimation()
    {
        float deltaX = Mathf.Abs(positionTankX - transform.position.x);
        stepidle++;
        if (deltaX > 0.03f)
        {
            if (positionTankX > transform.position.x)
            {
                curentSprite--;
                if (curentSprite < 0) curentSprite = spritesTank.Count - 1;
                caterpillar.SetAnimation(1);
            }
            else
            {
                curentSprite++;
                if (curentSprite >spritesTank.Count-1) curentSprite = 0;
                caterpillar.SetAnimation(0);
            }
        }
        else
        {
            if(stepidle > 2)
            {
                curentSprite++;
                if (curentSprite > spritesTank.Count - 1) curentSprite = 0;
                stepidle = 0;
            }
            caterpillar.SetAnimation(0);
        }
        spriteTank.sprite = spritesTank[curentSprite];
        positionTankX = transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bonus>())
        {
            GetBonus(collision.gameObject.GetComponent<Bonus>().id);
            PlayAudio(collision.gameObject.GetComponent<Bonus>().curentAudioclip);

        }
        Destroy(collision.gameObject);
    }
    private void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void GetBonus(int id)
    {
        switch (id)
        {
            case 0:
                IconsController.Instance.NuclearCountIncrease();
                break;
            case 1:
                Debug.Log(id);
                break;
            case 2:
                SpeedBoost();
                break;
            case 3:
                gun.GunPowerUP();
                break;
            case 4:
                gun.RateOfFire();
                break;
            case 5:
                gun.NextSpriteGun();
                break;
            case 6:
                Debug.Log(id);
                break;
            case 7:
                homing.UpdeteHoming();
                break;
            case 8:
                Debug.Log(id);
                break;
            case 9:
                rocketPlace.UpdeteRocket();
                break;
            case 10:
                Debug.Log(id);
                break;
            case 11:
                lightning.UpdeteLightning();
                break;
        }
        CreateWords.Instance.CreateWord(id);
    }
    private void SpeedBoost()
    {
        speed += 0.01f;
        if (speed >= maxSpeed) speed = maxSpeed;
    }
}
