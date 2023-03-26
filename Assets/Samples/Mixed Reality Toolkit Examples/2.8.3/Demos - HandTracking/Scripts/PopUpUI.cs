using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    string baseColorAndPatternColorQuestion = "당신이 떠올린 꿈은 어느 것에 가장 가깝습니까?";
    string[][] answers =    {
    new string[] { "혼자서도 이룰 수 있는", "다른 사람의 도움 없이 불가능한" },
    new string [] { "현실적 가치가 중요(수입, 명예, 안정성 등)", "이상적 가치가 중요(자아 실현, 이타성 등)"},
    new string [] { "그저 막연하다 (불가능일에 가까움)", "실현을 위해 노력해보고 싶다 " },
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
