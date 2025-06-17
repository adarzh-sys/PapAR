using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // Make sure VSync is disabled
    }
}
