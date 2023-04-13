using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARInteraction : MonoBehaviour
{
    [SerializeReference] private Camera arCamera;
    [SerializeReference] private GameObject originGame;
    [SerializeReference] private GameObject positionGame;
    private GameManager gameManager;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool isTouch;
    private bool isStartPosition;
    // Start is called before the first frame update

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!positionGame.activeSelf)
        {
            Vector2 centerPointScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            if(raycastManager.Raycast(centerPointScreen, hits, TrackableType.Planes))
            {
                positionGame.SetActive(true);
                positionGame.transform.position = hits[0].pose.position;
                positionGame.transform.rotation = hits[0].pose.rotation;
                //isStartPosition = true;
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);
            if (touchOne.phase == TouchPhase.Began)
            {
                isTouch = true;
            }
            else if (touchOne.phase == TouchPhase.Ended)
            {
                isTouch = false;
            }

            if (touchOne.phase == TouchPhase.Moved && isTouch)
            {
                if (raycastManager.Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Vector3 VisionDirection = new Vector3(arCamera.transform.forward.x, 0, arCamera.transform.forward.z).normalized;
                    Pose hitPose = hits[0].pose;
                    if (isTouch)
                    {
                        positionGame.transform.position = hitPose.position;
                        positionGame.transform.forward = VisionDirection;

                    }
                }
            }
        }
    }
    
}
