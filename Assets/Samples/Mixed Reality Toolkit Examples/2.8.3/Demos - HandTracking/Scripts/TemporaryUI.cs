using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TemporaryUI : MonoBehaviour
{
    string[] questions = new string[]
    {
        "[Q1] 꿈이 내 삶에서 차지하는 비중이 어느 정도라고 생각하나요?",
        "[Q2] 살면서 새로운 무언가 를 시작할 때, 본인이 더 중요하게 여기는 가치는 무엇인가요?",
        "[Q3] 최근 가지고 있었던 꿈에 대한 나의 생각을 골라보세요.",
        "[Q4] 새로운 꿈을 갖게 된 내가 가장 먼저 할 일로 가장 가까운 보기를 골라주세요."
    };

    public GameObject question;
    public GameObject[]answerTexts = new GameObject[4];
    string[][] answers =    {
    new string[] {"내 삶으로 대변되는 전부이다", "내 삶 속에 녹아있는 일부이다" },
    new string [] {"나는 과정보다 목표 성취를 중요하게 여긴다 ", "나는 목표 성취보다 과정을 중요하게 여긴다"},
    new string [] {"일어날 수 없어도, 그 자체로 의미가 있다", "일어날 수 없다면, 아무 의미 없다", "이룬다 했을 때, 내 삶에 미치는 영향이 크다", "이룬다 해도, 내 삶의 일부일 뿐이다" },
    new string [] { "두고두고 새길 수 있게 어딘가에 기록한다", "내 이야기를 들어줄 다른 사람에게 공유한다", "머릿속 어딘가에 흘러가게 내버려둔다" }
    };
    int currentIndex = 0;
    int[] answerNumbers;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        question.transform.GetComponent<TMP_Text>().text = questions[currentIndex];
        answerTexts[0].transform.GetComponent<TMP_Text>().text = answers[0][0];
        answerTexts[1].transform.GetComponent<TMP_Text>().text = answers[0][1];

        answerNumbers = new int[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void clickAnswer(int answerNumber)
    {
         answerNumbers[curretIndex] = answerNumber;
    }

    public void submitAnswer()
    {
        currentIndex++;
        // outline 넣기 
        if (currentIndex < questions.Length)
        {
            question.transform.GetComponent<TextMeshPro>().text = questions[currentIndex];
            for(int i = 0; i < answers[currentIndex].Length; i++) {
                answerTexts[i].transform.GetComponent<TextMeshPro>().text = answers[currentIndex][i];
            }
        }
        else
        {
           
            for(int i = 0; i < 4; i++)
            {
                TextWriterSingleton.addValue(answerNumbers[i].ToString());
            }
           
        }

    }

}
