using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoidUI : MonoBehaviour
{
    public GameObject[] answerSylinders = new GameObject[4];
    static int currentIndex = 0;
    static int DREAM_COLOR_NUMBER = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void submitAnswer(int answerNumber)
    {

        // outline �ֱ�
        Debug.Log("spoid ddd" + answerNumber);
        TextWriterSingleton.addValue(answerNumber.ToString());
    }

    public void selectLargeBox()
    {

    }
}
