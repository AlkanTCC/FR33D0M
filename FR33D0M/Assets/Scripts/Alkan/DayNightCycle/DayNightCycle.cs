using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.DebugUI;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] Light2D directionalLight;
    [SerializeField] float maxIntensity = 2f;
    [SerializeField] float minIntensity = 0.3f;
    [SerializeField] int secondsTillMax = 840;
    [SerializeField] float darkStart = 120f;
    [SerializeField] float darkEnd = 1320f;

    PlaytimeTracker playtimeTracker;
    float currentPlaytime;

    private void Start()
    {
        playtimeTracker = FindAnyObjectByType<PlaytimeTracker>();
    }

    private void FixedUpdate()
    {
        currentPlaytime = playtimeTracker.totalPlaytime;

        if (currentPlaytime <= secondsTillMax)
        {
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, currentPlaytime / secondsTillMax);
            directionalLight.intensity = intensity;
        }
        else
        {
            float intensity = Mathf.Lerp(maxIntensity, minIntensity, Mathf.Clamp01((currentPlaytime - secondsTillMax) / (24 * 60 - secondsTillMax)));
            directionalLight.intensity = intensity;
        }
    }
}