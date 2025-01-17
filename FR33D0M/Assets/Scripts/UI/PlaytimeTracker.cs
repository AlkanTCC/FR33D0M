using TMPro;
using UnityEngine;

public class PlaytimeTracker : MonoBehaviour
{
    // Gemaakt door Roni
    public float totalPlaytime;
    public TMP_Text playtimeText;
    public int dayCount = 0;
    public Vector2 time;

    [Header("Time Control")]
    public float timeMultiplier = 1f;

    private void Start()
    {
        InvokeRepeating("UpdatePlaytime", 0, 0.1f);
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdatePlaytime()
    {
        if (totalPlaytime == 1440)
        {
            totalPlaytime = 0;
            dayCount++;
        }
        else
        {
            totalPlaytime += 0.1f * timeMultiplier;
        }

        time = new Vector2(Mathf.FloorToInt((totalPlaytime / 60) % 24), Mathf.FloorToInt(totalPlaytime % 60));
        print(totalPlaytime);
    }

    void UpdateUI()
    {
        playtimeText.text = $"<color=yellow>{time.x:00}:{time.y:00}</color>";
    }
}