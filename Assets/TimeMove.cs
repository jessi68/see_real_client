using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMove : MonoBehaviour
{
    private float timeElasped = 0;
    private float waitTime = 5f;
    [SerializeField]
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElasped += Time.deltaTime;
        
        if(timeElasped > waitTime)
        {
            //cam.transform.position = new Vector3(-9.898f, 0.11f, -8.779f);
            //cam.transform.rotation = Quaternion.Euler(-1.814f, 206.092f, 6.028f);
            //cam.transform.position = new Vector3(-7.12f, -4.52f, -2.62f);
            //cam.transform.rotation = Quaternion.Euler(38.862f, -1.054f, -37.434f);
        }
    }
}
