using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamNumberUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentQuestion;
    public GameObject currentAnswers;
    public GameObject nextQuestion;
    public GameObject nextAnswers;
    //public GameObject mrtkPlayer;

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
        Debug.Log("dream ddd" + answerNumber);
        TextWriterSingleton.addValue(answerNumber.ToString());
        currentQuestion.SetActive(false);
        currentAnswers.SetActive(false);
     
        nextQuestion.SetActive(true);
        nextAnswers.SetActive(true);
    }
}
