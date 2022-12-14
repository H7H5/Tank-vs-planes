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
    public GameObject point;

    private List<Vector3> points = new List<Vector3>();
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CreatePoint();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeRtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && target !=null)
            {
                Shot();
               
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
        //GameObject lightning = Instantiate(LightningPrefab, gameObject.transform);
        //lightning.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartObject.gameObject.transform.position = gameObject.transform.position;
        //lightning.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndObject.gameObject.transform.position = target.transform.position;
        //Destroy(lightning, 0.3f);
        CreatePoint();
        float speed = 0.05f;
        for (int i = 0; i < 90; i++)
        {
                GameObject shot = Instantiate(point, transform.position, Quaternion.identity);
                shot.GetComponent<Flash>().step = i;
                shot.GetComponent<Flash>().points = points;
                shot.GetComponent<Flash>().speed = speed; 
                speed += 0.0004f;
        }
        timeRtwShots = startTimeRtwShots;
    }

    private void CreatePoint()
    {
        points = new List<Vector3>();
        float distantion = Vector3.Distance(gameObject.transform.position, target.transform.position);
        float cell = 1f;
        int count = (int)(distantion / cell);
        if(count == 0)
        {
            count = 1;
        }
        


        float z = transform.position.z;
        float distanceX = Mathf.Abs(transform.position.x - target.transform.position.x);
        float dX = distanceX / count;
        float distanceY = Mathf.Abs(transform.position.y - target.transform.position.y);
        float dY = distanceY / count;
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        for (int i = 0; i < count; i++)
        {
            if (transform.position.x > target.transform.position.x)
            {
                currentX -= dX;
            }
            else
            {
                currentX += dX;
            }
            if (transform.position.y >= target.transform.position.y)
            {
                currentY -= dY;
            }
            else
            {
                currentY += dY;
            }
            points.Add(new Vector3(currentX, currentY, z));
        }
        points = SetRandomPoint(points);
        for (int i = 0; i < points.Count; i++)
        {
            //Instantiate(point, points[i],Quaternion.identity);
        }
    }
    private List<Vector3> SetRandomPoint(List<Vector3> points)
    {
        if (points.Count > 2)
        {
            List<Vector3> curentPoints = new List<Vector3>();
            curentPoints.Add(points[0]);
            for (int i = 1; i < points.Count - 1; i++)
            {
                float randomX = Random.Range(-1f, 1f);
                float randomY = Random.Range(-0.4f, 0.4f);
                curentPoints.Add(new Vector3(points[i].x + randomX, points[i].y + randomY, points[i].z));
            }
            curentPoints.Add(points[points.Count - 1]);

            return curentPoints;
        }
        else
        {
            return points;
        }
       
    }
}
