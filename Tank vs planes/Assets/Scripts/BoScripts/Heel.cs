using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime);
    }
}
