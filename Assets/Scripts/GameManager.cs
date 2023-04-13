using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeReference] private GameObject originGame;
    [SerializeReference] private GameObject positionGame;
    private ARInteraction interaction;
    private UIManager uiManager;
    private void Awake()
    {
        interaction = FindObjectOfType<ARInteraction>();
        uiManager = FindObjectOfType<UIManager>();
        gameManager = (gameManager == null) ? this : null;
    }
    // Start is called before the first frame update
    void Start()
    {
        uiManager.GoPositionItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlaceItem()
    {
        originGame.SetActive(true);
        originGame.transform.position = positionGame.transform.position;
        originGame.transform.forward = positionGame.transform.forward;
        positionGame.SetActive(false);
    }
    public void PositionItem()
    {
        originGame.SetActive(false);
        positionGame.SetActive(false);
    }


}
