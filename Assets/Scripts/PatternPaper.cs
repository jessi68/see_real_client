using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternPaper : MonoBehaviour
{
    private bool patternChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        gameObject.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
    }
}
