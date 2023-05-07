using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoidInteractionStarter : InteractionStarter
{
    public GameObject dreamUI;
    private bool isShown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShown)
        {
            dreamUI.SetActive(true);
        }
    }

    public override void Observe()
    {
        isShown = true;
    }
}
