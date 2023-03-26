using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerField : MonoBehaviour
{
    
    float[] positionX = new float[] {0.4f, 2.6f, 0.1f, -1.6f, -2.1f, 1.2f, 1.9f, -0.4f};
    float[] positionZ = new float[] {3.4f, 3.6f, 2.1f, -2.6f, -0.1f, 3.2f, 1.9f, -1.6f};
    private GameObject FlowerPattern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateFlower(string flowerFile, GameObject _myFlower, int index)
    {
        string childIndexString = flowerFile.Substring(flowerFile.Length - 5);
        childIndexString = childIndexString.Substring(0, 1);
        int childIndex = int.Parse(childIndexString);
        Debug.Log(childIndex);
        GameObject myFlower = Instantiate(_myFlower, new Vector3(0, 0, 0), Quaternion.identity);
        myFlower.transform.parent = this.transform;
        myFlower.transform.localPosition = new Vector3(positionX[index], 0, positionZ[index]);
        myFlower.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        FlowerPattern = transform.GetChild(3).GetChild(childIndex).gameObject;
        byte[] byteTexture = System.IO.File.ReadAllBytes(flowerFile);
        Texture2D pattern = new Texture2D(0, 0);
        pattern.LoadImage(byteTexture);
        FlowerPattern.GetComponent<Renderer>().material.SetTexture("_BaseMap", pattern);
    }
}
