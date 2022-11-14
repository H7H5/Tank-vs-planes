using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWords : MonoBehaviour
{
    [SerializeField] private GameObject increased_rate_of_fire;
    [SerializeField] private GameObject fan_fire;
    [SerializeField] private GameObject improved_shield;
    [SerializeField] private GameObject received_the_atomic_bomb;
    [SerializeField] private GameObject increased_speed;
    [SerializeField] private GameObject increased_weapon_power;

    public static CreateWords Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateWord(int id)
    {
        switch (id)
        {
            case 0:
                Instantiate(received_the_atomic_bomb, transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(improved_shield, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(increased_speed, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(increased_weapon_power, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(increased_rate_of_fire, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(fan_fire, transform.position, Quaternion.identity);
                break;
        }
    }
}
