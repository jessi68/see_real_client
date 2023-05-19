using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoidUI : MonoBehaviour
{
    static int currentIndex = 0;
    static int DREAM_COLOR_NUMBER = 6;
    public GameObject currentQuestion;
    public GameObject nextQuestion;
    public GameObject nextAnswers;
    public GameObject mrtkPlayer;
    public Vector3 position;
    public Vector3 rotation;

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
        // outline ³Ö±â
        Debug.Log("spoid ddd" + answerNumber);
        TextWriterSingleton.addValue(answerNumber.ToString());
        currentQuestion.SetActive(false);
        mrtkPlayer.transform.position = position;
        mrtkPlayer.transform.rotation = Quaternion.Euler(rotation);
        nextQuestion.SetActive(true);
        nextAnswers.SetActive(true);
    }
}
