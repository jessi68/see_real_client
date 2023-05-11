using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private GameObject FlowerPattern;

    private Dictionary<string, float> flowerScales = new Dictionary<string, float>();

    // Start is called before the first frame update
    void Awake()
    {
        flowerScales.Add("dandelion2", 2.8f);
        flowerScales.Add("lavender2", 2.8f);
        flowerScales.Add("daisies", 1.8f);
        flowerScales.Add("rose5", 2.2f);
        flowerScales.Add("daisy", 2.7f);
        flowerScales.Add("roes7", 1.6f);
        flowerScales.Add("rose8", 1.4f);
        flowerScales.Add("rosebush", 1.8f);
        flowerScales.Add("smallbush", 2.6f);
        flowerScales.Add("branch", 24f);
        flowerScales.Add("minitree", 1.7f);
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
        myFlower.transform.localPosition = new Vector3(0f, 0f, 0f);

        string flowerName = flowerFile.Split('_')[0];
        string flowerType = flowerFile.Split('_')[1];
        if(flowerName == "rose" || flowerName == "dandelion" || flowerName == "lavender") {
            flowerName = string.Concat(flowerName, flowerType);
        }
        flowerName = flowerName.Split('\\')[1];
        float flowerScale = 0f;
        if(!flowerScales.ContainsKey(flowerName)) {
            flowerScale = 2f;
        } else {
            flowerScale = flowerScales[flowerName];
        }

        myFlower.transform.localScale = new Vector3(flowerScale, flowerScale, flowerScale);
        FlowerPattern = transform.GetChild(3).GetChild(childIndex).gameObject;
        byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFile);
        Texture2D pattern = new Texture2D(0, 0);
        pattern.LoadImage(byteTexture);
        FlowerPattern.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
    }
}
