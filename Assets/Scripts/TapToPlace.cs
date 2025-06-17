using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class TapToPlace : MonoBehaviour
{
    public GameObject placeablePrefab;
    public Slider scaleSlider;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        // Use FindFirstObjectByType (cleaner, avoids warning)
        raycastManager = FindFirstObjectByType<ARRaycastManager>();
        if (scaleSlider != null)
            scaleSlider.onValueChanged.AddListener(UpdateScale);
    }

    void Update()
    {
        if (Input.touchCount == 0 || raycastManager == null)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            // If object already exists, destroy it first
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }

            // Instantiate new object
            spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
            spawnedObject.transform.localScale = Vector3.one * 0.01f;

            // Set initial scale (slider value)
            if (scaleSlider != null)
            {
                UpdateScale(scaleSlider.value);
            }
        }
    }

    void UpdateScale(float value)
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.localScale = Vector3.one * value;
        }
    }
}
