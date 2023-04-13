using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas canvas;
    [SerializeField] Button placeItemButton;
    [SerializeField] Button positionItemButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        canvas.transform.forward = mainCamera.transform.forward;
    }
    public void GoPlaceItem()
    {
        placeItemButton.enabled = true;
        positionItemButton.enabled = false;
        
    }
    public void GoPositionItem() {
        placeItemButton.enabled = false;
        positionItemButton.enabled = true;
    } 
}
