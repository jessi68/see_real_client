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
    private GameObject TCPClient;
    [SerializeField]
    private GameObject[] Flowers;
    private int totalFlowerNum;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // generateFlower();
        getTotalFlowerNum();
        generateFlowerinField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finishGeneration(string fileName) {
        generateFlower(fileName);
        getTotalFlowerNum();
        generateFlowerinField();
    }

    public void getTotalFlowerNum() {
        string rootdir = "./Assets/Resources/Textures";
        string[] files = Directory.GetFiles(rootdir);
        int _totalFlowerNum = 0;
        for (int i = 0; i < files.Length; i++) {
            if (files[i].Substring(files[i].Length - 3) == "png") {
                _totalFlowerNum += 1;
            }
        }
        totalFlowerNum = _totalFlowerNum;
    }

    public void endOfExperiment(string answers) {
        TCPClient.GetComponent<TCPClient>().Send(answers);
    }

    public void generateFlower(string fileName) {
        string rootdir = "./Assets/Resources/Textures";
        string[] files = Directory.GetFiles(rootdir);
        string flowerFile = "";
        for (int i = 0; i < files.Length; i++) {
            if (files[i].Contains(fileName)) {
                // if (files[i].Length > 4 && files[i].Substring(files[i].Length - 3) == "png") {
                //     flowerFile = files[i];
                // }
                flowerFile = files[i];
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
        string[] names = new string[] {"이서윤", "허가영", "신민재", "김주하", "전세윤"};
        string rootdir = "./Assets/Resources/Textures";
        string[] files = Directory.GetFiles(rootdir);
        string[] flowerFiles = new string[totalFlowerNum];
        GameObject[] myFlowers = new GameObject[totalFlowerNum];
        int k = 0;
        for (int i = 0; i< files.Length; i++) {
            string flowerFile = ""; 
            if(files[i].Length > 4 && files[i].Substring(files[i].Length - 3) == "png") {
                flowerFile = files[i];
            }

            GameObject myFlower = Flowers[0];
            Debug.Log(flowerFile);

            string flowerStructure = flowerFile.Substring(rootdir.Length + 1);
            flowerStructure = flowerStructure.Substring(0, flowerStructure.Length - 9);

            for(int j = 0; j < Flowers.Length; j++) {
                if (Flowers[j].ToString().Contains(flowerStructure)) {
                    myFlower = Flowers[j];
                }
            }  

            flowerFiles[k] = flowerFile;    
            myFlowers[k] = myFlower;

            k += 1;
        }
        FlowerField.GetComponent<FlowerField>().generateFlower(flowerFiles, myFlowers);
    }
}
