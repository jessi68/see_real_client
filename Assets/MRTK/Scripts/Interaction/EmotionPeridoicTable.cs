using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionPeridoicTable : MonoBehaviour
{
    bool[] selected = new bool[18];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 18; i++)
        {
            selected[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Toggle(int index)
    {
        if (selected[index])
        {
            selected[index] = false;
        }
        else
        {
            selected[index] = true;
        }
    }

    void Complete()
    {
        string content = "";
        int selectedNumber = 0;

        for (int i = 0; i < 18; i++)
        {
            if (selected[i])
            {
                content += (i + 1);
                content += ",";
                selectedNumber += 1;

            }
        }

        TextWriterSingleton.addValue(selectedNumber + "," + content.Substring(0, content.Length - 1));
    }
}