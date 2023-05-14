using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.ExceptionServices;

public class TemporaryUI : MonoBehaviour
{
    string[] questions = new string[]
    {
        "[Q1] ���� �� ��� \n �����ϴ� ������ \n ��� ������� \n �����ϳ���?",
        "[Q2] ��鼭 ���ο� ���� \n ���� ������ ��, ������ �� \n �߿� �ϰ� ����� ��ġ��\n �����ΰ���?",
        "[Q3] �ֱ� ������ �־��� �� \n �� ���� ���� ������ \n ��󺸼���.",
        "[Q4] ���ο� ���� ���� \n �� ���� ���� ���� �� \n �Ϸ� ���� ����� ���⸦ \n ����ּ���."
    };

    public GameObject question;
    public GameObject[]answerTexts = new GameObject[4];
    public GameObject[] answerToggles = new GameObject[4];
    public GameObject labSpace;
    public GameObject nextQuestion;
    public GameObject parentOfnextAnswers;
    public GameObject currrentAnswers;
    string[][] answers =    {
    new string[] {"�� ������ �뺯�Ǵ� \n �����̴�", "�� �� �ӿ� ��� \n �ִ� �Ϻ��̴�" },
    new string [] {"���� �������� ��ǥ \n ���븦 �߿��ϰ� ����� ", "���� ��ǥ ���뺸�� \n ������ �߿��ϰ� �����"},
    new string [] {"�Ͼ �� ���, \n �� ��ü�� �ǹ̰� �ִ�", "�Ͼ �� ���ٸ�, \n �ƹ� �ǹ� ����", "�̷�� ���� ��, \n �� � ��ġ�� ������ ũ��", "�̷�� �ص�, \n �� ���� �Ϻ��� ���̴�" },
    new string [] { "�ΰ�ΰ� ���� �� �ְ� \n ��򰡿� ����Ѵ�", "�� �̾߱⸦ ����� \n �ٸ� ������� �����Ѵ�", "�Ӹ��� ��򰡿� \n �귯���� �������д�" }
    };
    static int currentIndex = 0;
    static int[] answerNumbers;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        question.transform.GetComponent<TMP_Text>().text = questions[currentIndex];
        answerTexts[0].transform.GetComponent<TMP_Text>().text = answers[0][0];
        answerTexts[1].transform.GetComponent<TMP_Text>().text = answers[0][1];

        answerNumbers = new int[4];

        for(int i = 0; i < 2; i++)
        {
            answerToggles[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void clickAnswer(int answerNumber)
    {
         answerNumbers[currentIndex] = answerNumber;
    }

    public void submitAnswer(int answerNumber)
    {
        
        // outline �ֱ� 

        if(currentIndex == questions.Length)
        {
            return;
        }

        answerNumbers[currentIndex] = answerNumber;
        currentIndex++;
        Debug.Log(currentIndex);

        if (currentIndex != questions.Length)
        {
            question.transform.GetComponent<TMP_Text>().text = questions[currentIndex];
            for (int i = 0; i < answers[currentIndex].Length; i++)
            {
                answerTexts[i].transform.GetComponent<TMP_Text>().text = answers[currentIndex][i];
            }

            for(int i = 0; i < 4;i++)
            {
                answerToggles[i].SetActive(false);
            }

            for (int i = 0; i < answers[currentIndex].Length; i++)
            {
                answerToggles[i].SetActive(true);
            }
        }    
        else
        {
           
            for(int i = 0; i < 4; i++)
            {
                Debug.Log(i + "��° ���� �ε����� " + answerNumbers[i] + "�Դϴ�.");
                TextWriterSingleton.addValue(answerNumbers[i].ToString());
            }

            labSpace.transform.position = new Vector3(-1.69f, -0.25f, 3.66f);
            labSpace.transform.rotation = Quaternion.Euler(0, -156.817f, 0);
            currrentAnswers.SetActive(false);
            nextQuestion.SetActive(true);
            
            parentOfnextAnswers.SetActive(true);
            
        }
    }
}
