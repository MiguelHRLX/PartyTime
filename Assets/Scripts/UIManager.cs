using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        canvas.transform.forward = mainCamera.transform.forward;
    }
}
