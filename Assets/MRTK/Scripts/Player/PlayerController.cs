using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isUpdated = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUpdated)
        {
            
            transform.position = new Vector3(-3.49f, -3.35f, 0f);
            transform.rotation = Quaternion.Euler(0f, 183.06f, 0f);
            isUpdated = true; 
        }
    
    }
}
