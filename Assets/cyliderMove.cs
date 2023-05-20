using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyliderMove : MonoBehaviour
{
    int pushableNumber;
    bool isCylinderMoveable;
    [SerializeField]
    GameObject cylinder;
    [SerializeField]
    GameObject currentQuestion;
    [SerializeField]
    GameObject nextQuestion;
    [SerializeField]
    GameObject mrtkPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isCylinderMoveable = false;
        pushableNumber = 0;
    }

    void SelectBeaker(int beakerNumber)
    {
        pushableNumber = beakerNumber;
    }

    void selectSpoid()
    {
        cylinder.transform.position = new Vector3(cylinder.transform.position.x, cylinder.transform.position.y, cylinder.transform.position.z);
        isCylinderMoveable = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isCylinderMoveable)
        {
            if (transform.position.y > 0.65)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * 0.1f, transform.position.z);
            }
            else
            {
                isCylinderMoveable = false;
                pushableNumber -= 1;

                // ³²Àº È½¼ö - 1

                if (pushableNumber == 0)
                {
                    currentQuestion.SetActive(false);
                    nextQuestion.SetActive(true);
                    // change camera position 
                    mrtkPlayer.transform.position = nextQuestion.transform.position + new Vector3(0, 1, 0);
                    //mrtkPlayer.transform.rotation = Quaternion.Euler(-1.814f, 206.092f, 6.028f);
                    Debug.Log("go to flask");
                    // go to flask 
                }
            }
        }
        

    }
}
