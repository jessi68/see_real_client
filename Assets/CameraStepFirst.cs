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
        waitTime = 1f;
        isUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElasped += Time.deltaTime;
        Debug.Log(timeElasped);
        if(timeElasped >= waitTime && isUpdated == false)
        {
            Debug.Log("well done");
            isUpdated = true;

            // first place
            this.transform.position = new Vector3(-14.39f, 2.01f, -8.84f);
            this.transform.rotation = Quaternion.Euler(6.145f, -158.08f, 1.361f);

            // lab space 
            transform.position = new Vector3(-9.828f, 0.181f, -8.962f);
            transform.rotation = Quaternion.Euler(3.128f, 159.7f, 5.464f);
        }
    }
}
