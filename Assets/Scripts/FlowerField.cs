using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerField : MonoBehaviour
{
    
    float[] positionX = new float[] {0.4f, 2.6f, 0.1f, -1.6f, -2.1f, 1.2f, 1.9f, -0.4f};
    float[] positionZ = new float[] {3.4f, 3.6f, 2.1f, -2.6f, -0.1f, 3.2f, 1.9f, -1.6f};
    private GameObject FlowerPattern;

    private Dictionary<string, float> flowerScales = new Dictionary<string, float>();

    // Start is called before the first frame update
    void Awake()
    {
        flowerScales.Add("dandelion2", 4.2f);
        flowerScales.Add("lavender2", 4.2f);
        flowerScales.Add("daisies", 2.7f);
        flowerScales.Add("rose5", 3.3f);
        flowerScales.Add("daisy", 4.1f);
        flowerScales.Add("roes7", 2.4f);
        flowerScales.Add("rose8", 2.1f);
        flowerScales.Add("rosebush", 2.7f);
        flowerScales.Add("smallbush", 3.9f);
        flowerScales.Add("branch", 36f);
        flowerScales.Add("minitree", 2.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateFlower(string[] flowerFiles, GameObject[] _myFlowers)
    {
        Debug.Log(flowerFiles.Length);
        for (int i = 0; i < flowerFiles.Length; i++) {
            string flowerFile = flowerFiles[i];
            GameObject _myFlower = _myFlowers[i];
            int index = i;
            string childIndexString = flowerFile.Substring(flowerFile.Length - 5);
            childIndexString = childIndexString.Substring(0, 1);
            int childIndex = int.Parse(childIndexString);
            GameObject myFlower = Instantiate(_myFlower, new Vector3(0, 0, 0), Quaternion.identity);
            myFlower.transform.parent = this.transform;
            myFlower.transform.localPosition = new Vector3(positionX[index], 0.035f, positionZ[index]);

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
            FlowerPattern = transform.GetChild(i+1).GetChild(childIndex).gameObject;
            byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFile);
            Texture2D pattern = new Texture2D(0, 0);
            pattern.LoadImage(byteTexture);
            FlowerPattern.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
        }
    }
}
