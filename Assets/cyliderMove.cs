using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyliderMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(transform.position.y > 0.6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 0.1f, transform.position.z);
        }

    }
}
