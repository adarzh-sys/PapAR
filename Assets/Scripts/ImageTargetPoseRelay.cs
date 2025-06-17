using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPoseRelay : MonoBehaviour
{
    public GameObject sharedAnchor;
    public TMPro.TextMeshProUGUI trackingLabel; // Optional: live debug label

    private List<ImageTargetBehaviour> imageTargets = new List<ImageTargetBehaviour>();
    private ImageTargetBehaviour currentTarget = null;

    void Start()
    {
        imageTargets.AddRange(FindObjectsOfType<ImageTargetBehaviour>());

        foreach (var target in imageTargets)
        {
            var observer = target.GetComponent<ObserverBehaviour>();
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            if (currentTarget != behaviour)
            {
                currentTarget = behaviour as ImageTargetBehaviour;
                UpdateAnchorPose();

                if (trackingLabel != null)
                    trackingLabel.text = $"Tracking: {currentTarget.TargetName}";
            }
        }
    }

    void UpdateAnchorPose()
    {
        if (sharedAnchor == null || currentTarget == null)
            return;

        sharedAnchor.transform.SetPositionAndRotation(
            currentTarget.transform.position,
            currentTarget.transform.rotation
        );
    }
}
