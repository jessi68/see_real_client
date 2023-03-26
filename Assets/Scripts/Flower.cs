using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private GameObject FlowerPattern;
    private bool patternChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        FlowerPattern = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!patternChanged) {
            changePattern();
            patternChanged = true;
        }
    }

    public void changePattern()
    {
        byte[] byteTexture = System.IO.File.ReadAllBytes("./Assets/Resources/Textures/test.png");
        Texture2D pattern = new Texture2D(0, 0);
        pattern.LoadImage(byteTexture);
        FlowerPattern.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
    }
}
