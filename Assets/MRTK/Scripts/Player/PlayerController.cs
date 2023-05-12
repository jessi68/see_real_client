using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isUpdated = false;
    float elaspedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        elaspedTime += Time.deltaTime;
        Debug.Log(elaspedTime);

        if(elaspedTime > 5 && isUpdated == false) { 
            transform.position = new Vector3(-3.980347f, -5.62f, -2.959058f);
            transform.rotation = Quaternion.Euler(0f, 183.06f, 0f);
            Debug.Log("eeeeee");
            isUpdated = true; 
        }

    
    }
}
