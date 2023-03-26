using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlowerAnswer : MonoBehaviour
{
    public int flowerAnswerNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clickAnswer()
    {
        TMP_Text text = this.gameObject.transform.GetComponent<TMP_Text>();
        if(text.color == Color.red)
        {
            text.color = Color.black;
        } else
        {
            text.color = Color.red;
            TemporaryUI.clickAnswer(flowerAnswerNumber);
       
        }
    }
}
