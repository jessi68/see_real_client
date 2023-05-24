using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerField : MonoBehaviour
{
    
    float[] positionX = new float[1000];
    float[] positionZ = new float[1000];
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

    void Start() {
        string fileDir = "./Assets/Resources/Position/positionOutdoor.txt";
        string positionData = System.IO.File.ReadAllText(fileDir);
        string[] positionDataArray = positionData.Split('\n');
        string[] positions = new string[3];
        for (int i = 0; i < positionDataArray.Length; i++) {
            positions = positionDataArray[i].Split(',');
            positionX[i] = float.Parse(positions[0]);
            positionZ[i] = float.Parse(positions[2]);
        }
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
