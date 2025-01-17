using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] Light2D directionalLight;
    [SerializeField] float maxIntensity = 2f;  // Maximum intensity at 3 PM
    [SerializeField] float minIntensity = 0.3f;  // Minimum intensity at midnight
    [SerializeField] float fullDayDuration = 86400f;  // Full day duration in seconds (24 hours)

    private PlaytimeTracker playtimeTracker;
    private float currentPlaytime;

    private void Start()
    {
        playtimeTracker = FindAnyObjectByType<PlaytimeTracker>();
    }

    private void Update()
    {
        // Get the current playtime directly from PlaytimeTracker
        currentPlaytime = playtimeTracker.totalPlaytime % fullDayDuration;

        // Update the light intensity based on the current playtime
        UpdateLightIntensity(currentPlaytime);
    }

    private void UpdateLightIntensity(float playtime)
    {
        // Normalize playtime to the range [0, 1] for the full day
        float normalizedTime = playtime / fullDayDuration;

        // Define the peak time at 15:00 (3 PM), which is 15/24 = 0.625 of the day
        float peakTime = 0.625f;  // 3 PM is 0.625 of the full day

        // Shift the normalized time to create a curve that increases to 1 at 3 PM, and then decreases
        float timeFromMidnight = normalizedTime - peakTime;

        // Use Mathf.Sin to create the smooth rise and fall, scaled to the desired range
        float intensity = Mathf.Sin(timeFromMidnight * Mathf.PI);  // From -1 to 1

        // Map the sine value from [-1, 1] to the intensity range [minIntensity, maxIntensity]
        intensity = Mathf.Lerp(minIntensity, maxIntensity, (intensity + 1f) * 0.5f);

        // Set the directional light's intensity
        directionalLight.intensity = intensity;
    }
}
