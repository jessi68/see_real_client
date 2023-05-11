using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-3.49f, -3.35f, 0f);
        transform.rotation = Quaternion.Euler(0f, 183.06f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
