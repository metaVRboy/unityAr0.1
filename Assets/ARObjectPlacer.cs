using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARObjectPlacer : MonoBehaviour
{
    public GameObject objectToPlace; // Yerleþtirilecek obje (Cube)
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    // Obje zaten varsa, yerine taþý
                    if (objectToPlace.activeInHierarchy)
                    {
                        objectToPlace.transform.position = hitPose.position;
                    }
                    else
                    {
                        objectToPlace.SetActive(true);
                        objectToPlace.transform.position = hitPose.position;
                    }
                }
            }
        }
    }
}