using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternPaper : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changePattern(string flowerFile, GameObject myFlower)
    {
        Debug.Log("changePatternPaper");
        byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFile);
        Debug.Log("readfile");
        Texture2D pattern = new Texture2D(0, 0);
        pattern.LoadImage(byteTexture);
        Debug.Log("generateImage");
        gameObject.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
        Debug.Log("End");
    }
}
