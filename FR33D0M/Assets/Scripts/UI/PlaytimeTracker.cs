using TMPro;
using UnityEngine;

public class PlaytimeTracker : MonoBehaviour
{
    // Gemaakt door Roni
    public float totalPlaytime;
    public TMP_Text playtimeText;
    public int dayCount = 0;

    [Header("Time Control")]
    public float timeMultiplier = 1f;

    void Update()
    {
        UpdatePlaytime(Time.deltaTime * timeMultiplier);
        UpdateUI();
    }

    public void UpdatePlaytime(float deltaTime)
    {
        totalPlaytime += deltaTime / 2;

        if (totalPlaytime >= 24 * 60 * 60)
        {
            totalPlaytime = 0;
            dayCount++;
        }
    }

    private void UpdateUI()
    {
        int hours = Mathf.FloorToInt((totalPlaytime / 60) % 24);
        int minutes = Mathf.FloorToInt(totalPlaytime % 60);

        playtimeText.text = $"<color=yellow>{hours:00}:{minutes:00}</color>";
    }
}