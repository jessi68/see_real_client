using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generatePattern(string[] flowerFiles, int length)
    {
        for(int i = 0; i < length; i++) {
            byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFiles[i]);
            Texture2D pattern = new Texture2D(0, 0);
            pattern.LoadImage(byteTexture);
            transform.GetChild(i).gameObject.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
        }
    }
}
