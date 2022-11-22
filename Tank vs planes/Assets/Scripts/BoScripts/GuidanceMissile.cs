using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceMissile : MonoBehaviour
{
    private float offset = -90;
    [SerializeField] private List<Sprite> spritesMissile = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diferense = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ;
        rotateZ = Mathf.Atan2(diferense.y, diferense.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        //SelectImage(rotateZ);

    }
    private void SelectImage(float rotateZ)
    {
        int number = 0;
        if (rotateZ >= -15)
        {
            number = Mathf.Abs((int)(rotateZ / 15));
        }
        else
        {
            number = spritesMissile.Count-1-(Mathf.Abs((int)(rotateZ / 20)));
        }
        spriteRenderer.sprite = spritesMissile[number];

    }
}
