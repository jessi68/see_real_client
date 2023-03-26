using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCreateHandler : MonoBehaviour
{
    private LineRenderer _circleRenderer = null;
    [SerializeField]
    private GameObject petri;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("image create handler");
        _circleRenderer = GetComponent<LineRenderer>();
        _circleRenderer.enabled = false;
        //
    }

    // Update is called once per frame
    void Update()
    {
       if(_circleRenderer != null) {
        
       }
    }

    public void OnDropAndCreateCircle() {
        Debug.Log("on drop and create circle");
        Debug.Log(transform.position);

        if(_circleRenderer.enabled == false) {
        DrawCircle(100, (float)0.01);
        }
    }

    private void DrawCircle(int steps, float radius)
    {
        Color selectedColor = Color.red;

        _circleRenderer = GetComponent<LineRenderer>();
        _circleRenderer.enabled = true;
        _circleRenderer.positionCount = steps;
       
         Vector3[] positions = new Vector3[steps + 1];
        for (int i = 0; i <= steps; i++)
        {
            float angle = i * Mathf.PI * 2 / steps;
            positions[i] = new Vector3(Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle) * radius) + petri.transform.position;
        }

        // set the positions in the LineRenderer component
        _circleRenderer.positionCount = steps + 1;
        _circleRenderer.SetPositions(positions);
        _circleRenderer.material = new Material(Shader.Find("Particles/Standard Surface"));
        _circleRenderer.material.color = selectedColor;
        _circleRenderer.startWidth = 0.1f;
        _circleRenderer.endWidth = 0.1f;
    }
}
