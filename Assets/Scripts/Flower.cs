using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private GameObject FlowerPattern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changePattern(string flowerFile, GameObject _myFlower)
    {
        string childIndexString = flowerFile.Substring(flowerFile.Length - 5);
        childIndexString = childIndexString.Substring(0, 1);
        int childIndex = int.Parse(childIndexString);
        GameObject myFlower = Instantiate(_myFlower, new Vector3(0, 0, 0), Quaternion.identity);
        myFlower.transform.parent = this.transform;
        myFlower.transform.localPosition = new Vector3(0.02283556f, -0.2756133f, 0.009458799f);
        myFlower.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        FlowerPattern = transform.GetChild(3).GetChild(childIndex).gameObject;
        byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFile);
        Texture2D pattern = new Texture2D(0, 0);
        pattern.LoadImage(byteTexture);
        FlowerPattern.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
    }
}
