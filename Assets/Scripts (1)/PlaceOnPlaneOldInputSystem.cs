using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlaneOldInputSystem : MonoBehaviour
{
    [SerializeField]
    GameObject placedPrefab;

    GameObject spawnedObject;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    bool hasPlacedObject = false; // Add a flag to check if the object has been placed

    void Awake()
    {
        aRRaycastManager = GetComponent < ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (!hasPlacedObject) // Only allow placement if the object hasn't been placed yet
        {
            if (aRRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
                    //spawnedObject = Instantiate(placedPrefab, placedPrefab.transform.position, placedPrefab.transform.rotation);
                    hasPlacedObject = true; // Set the flag to true once the object is placed
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                    spawnedObject.transform.rotation = hitPose.rotation;
                }
            }
        }
    }
}
