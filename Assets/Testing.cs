using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testing()
    {
        Debug.Log("testing function works");
        camera.transform.position = new Vector3(-5.03f, 1.45f, -7.17f);
        camera.transform.rotation = Quaternion.Euler(0f, 151.15f, 0f);
    }
}
