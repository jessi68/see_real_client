using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerIndoor : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateFlower(string[] flowerFiles, GameObject[] _myFlowers, int length)
    {
        for (int i = 0; i < length; i++) {
            string flowerFile = flowerFiles[i];
            GameObject _myFlower = _myFlowers[i];
            int index = i;
            string childIndexString = flowerFile.Substring(flowerFile.Length - 5);
            childIndexString = childIndexString.Substring(0, 1);
            int childIndex = int.Parse(childIndexString);
            GameObject myFlower = Instantiate(_myFlower, new Vector3(0, 0, 0), Quaternion.identity);
            myFlower.transform.parent = this.transform.GetChild(i);
            myFlower.transform.localPosition = new Vector3(0,0,0);

            string flowerName = flowerFile.Split('_')[0];
            string flowerType = flowerFile.Split('_')[1];
            if(flowerName == "rose") {
                flowerName = string.Concat(flowerName, flowerType);
            }
            flowerName = flowerName.Split('\\')[1];
            float flowerScale = 0f;
            if(!flowerScales.ContainsKey(flowerName)) {
                flowerScale = 3f;
            } else {
                flowerScale = flowerScales[flowerName];
            }

            myFlower.transform.localScale = new Vector3(flowerScale, flowerScale, flowerScale);
            FlowerPattern = transform.GetChild(i).GetChild(0).GetChild(childIndex).gameObject;
            byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFile);
            Texture2D pattern = new Texture2D(0, 0);
            pattern.LoadImage(byteTexture);
            FlowerPattern.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
        }
    }
}
