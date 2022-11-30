using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] GameObject LightningPrefab;
    [SerializeField] GameObject target;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> spritesLightning = new List<Sprite>();
    private float timeRtwShots = 0;
    private float startTimeRtwShots = 1f;
    private int level = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && target !=null)
            {
                Shot();
                timeRtwShots = startTimeRtwShots;
            }
        }
        else
        {
            timeRtwShots -= Time.deltaTime;
        }
    }

    public void UpdeteLightning()
    {
        level++;
        if (level > 3)
        {
            level = 3;
        }
        spriteRenderer.sprite = spritesLightning[level - 1];
    }

    private void Shot()
    {
        GameObject lightning = Instantiate(LightningPrefab, gameObject.transform);
        lightning.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartObject.gameObject.transform.position = gameObject.transform.position;
        lightning.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndObject.gameObject.transform.position = target.transform.position;
        Destroy(lightning, 0.3f);
    }
}
