using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStepFirst : MonoBehaviour
{
    bool isUpdated = false;
    float timeElasped;
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        timeElasped = 0;
        waitTime = 0.5f;
        isUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElasped += Time.deltaTime;
      
        if(timeElasped >= waitTime && isUpdated == false)
        {
            isUpdated = true;

            // first place
            //this.transform.position = new Vector3(-13.17f, 1.45f, -3.27f);
            //this.transform.rotation = Quaternion.Euler(-3.708f, -224.607f, 5.089f);

            // strange
            //transform.position = new Vector3(-7.12f, -4.52f, -2.62f);
            //transform.rotation = Quaternion.Euler(38.862f, -1.054f, -37.434f);

            // lab space 

            transform.position = new Vector3(-9.17f, 0.261f, -8.937f);
            transform.rotation = Quaternion.Euler(-1.491f, -114.793f, 7.555f);
        }
    }
}
