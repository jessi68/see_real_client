using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibitionManager : MonoBehaviour
{

    private string Name = "신민재";
    [SerializeField]
    private GameObject Flower;
    [SerializeField]
    private GameObject PatternPaper;
    [SerializeField]
    private GameObject FlowerField;
    [SerializeField]
    private GameObject[] Flowers;

    // Start is called before the first frame update
    void Start()
    {
        generateFlower();
        generateFlowerinField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateFlower() {
        string rootdir = "./Assets/Resources/Textures";
        string[] files = Directory.GetFiles(rootdir);
        string flowerFile = "";
        for (int i = 0; i < files.Length; i++) {
            if (files[i].Contains(Name)) {
                if (files[i].Length > 4 && files[i].Substring(files[i].Length - 3) == "png") {
                    flowerFile = files[i];
                }
            }
        }

        GameObject myFlower = Flowers[0];

        string flowerStructure = flowerFile.Substring(rootdir.Length + 1);
        flowerStructure = flowerStructure.Substring(0, flowerStructure.Length - 9);
        // Debug.Log(flowerStructure);
        for (int i = 0; i < Flowers.Length; i++) {
            if (Flowers[i].ToString().Contains(flowerStructure)) {
                myFlower = Flowers[i];
            }
        }
        Flower.GetComponent<Flower>().changePattern(flowerFile, myFlower);
        PatternPaper.GetComponent<PatternPaper>().changePattern(flowerFile, myFlower);
    }

    public void generateFlowerinField() {
        for (int k = 0; k < 8; k++) {
            string[] names = new string[] {"이서윤", "허가영", "신민재", "허가영", "김주하", "전세윤", "김주하", "신민재"};
            string rootdir = "./Assets/Resources/Textures";
            string[] files = Directory.GetFiles(rootdir);
            string flowerFile = "";
            for (int i = 0; i < files.Length; i++) {
                if (files[i].Contains(names[k])) {
                    if (files[i].Length > 4 && files[i].Substring(files[i].Length - 3) == "png") {
                        flowerFile = files[i];
                    }
                }
            }

            GameObject myFlower = Flowers[0];

            string flowerStructure = flowerFile.Substring(rootdir.Length + 1);
            flowerStructure = flowerStructure.Substring(0, flowerStructure.Length - 9);
            // Debug.Log(flowerStructure);
            for (int i = 0; i < Flowers.Length; i++) {
                if (Flowers[i].ToString().Contains(flowerStructure)) {
                    myFlower = Flowers[i];
                }
            }
            FlowerField.GetComponent<FlowerField>().generateFlower(flowerFile, myFlower, k);
        }
    }
}
