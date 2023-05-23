using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    [SerializeField]
    public GameObject basicLight;
    private float timeElasped = 0;
    private float waitTime = 3f;
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
            basicLight.SetActive(true);
        }
    }
}
