using OVR.OpenVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoidActivateToggle : MonoBehaviour
{
    public GameObject frontPalte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeHeadUnclickable()
    {
          frontPalte.SetActive(false);
    }

    public void MakeHeadClickable()
    {
        frontPalte.SetActive(true);
    }
}
