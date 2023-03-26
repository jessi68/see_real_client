using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TemporaryUI : MonoBehaviour
{
    string[] questions = new string[]
    {
        "[Q1] ���� �� ��� �����ϴ� ������ ��� ������� �����ϳ���?",
        "[Q2] ��鼭 ���ο� ���� �� ������ ��, ������ �� �߿��ϰ� ����� ��ġ�� �����ΰ���?",
        "[Q3] �ֱ� ������ �־��� �޿� ���� ���� ������ ��󺸼���.",
        "[Q4] ���ο� ���� ���� �� ���� ���� ���� �� �Ϸ� ���� ����� ���⸦ ����ּ���."
    };

    public GameObject question;
    public GameObject[]answerTexts = new GameObject[4];
    string[][] answers =    {
    new string[] {"�� ������ �뺯�Ǵ� �����̴�", "�� �� �ӿ� ����ִ� �Ϻ��̴�" },
    new string [] {"���� �������� ��ǥ ���븦 �߿��ϰ� ����� ", "���� ��ǥ ���뺸�� ������ �߿��ϰ� �����"},
    new string [] {"�Ͼ �� ���, �� ��ü�� �ǹ̰� �ִ�", "�Ͼ �� ���ٸ�, �ƹ� �ǹ� ����", "�̷�� ���� ��, �� � ��ġ�� ������ ũ��", "�̷�� �ص�, �� ���� �Ϻ��� ���̴�" },
    new string [] { "�ΰ�ΰ� ���� �� �ְ� ��򰡿� ����Ѵ�", "�� �̾߱⸦ ����� �ٸ� ������� �����Ѵ�", "�Ӹ��� ��򰡿� �귯���� �������д�" }
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
        // outline �ֱ� 
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
