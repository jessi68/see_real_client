using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    string baseColorAndPatternColorQuestion = "����� ���ø� ���� ��� �Ϳ� ���� �������ϱ�?";
    string[][] answers =    {
    new string[] { "ȥ�ڼ��� �̷� �� �ִ�", "�ٸ� ����� ���� ���� �Ұ�����" },
    new string [] { "������ ��ġ�� �߿�(����, ��, ������ ��)", "�̻��� ��ġ�� �߿�(�ھ� ����, ��Ÿ�� ��)"},
    new string [] { "���� �����ϴ� (�Ұ����Ͽ� �����)", "������ ���� ����غ��� �ʹ� " },
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ChangeToNextAnswer(int dreamAnswerIndex)
    {

    }
}
