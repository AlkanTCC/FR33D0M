using TMPro;
using UnityEngine;
using UnityEngine.UI; 
public class PlaytimeTracker : MonoBehaviour
{
    //Gemaakt door Roni
    private float totalPlaytime;
    public TMP_Text playtimeText; 

    void Update()
    {
        UpdatePlaytime(Time.deltaTime);
        UpdateUI(); 
    }

    public void UpdatePlaytime(float deltaTime)
    {
        totalPlaytime += deltaTime;
    }

    public float GetTotalPlaytime()
    {
        return totalPlaytime;
    }

    public void ResetPlaytime()
    {
        totalPlaytime = 0;
    }

    public void SavePlaytime()
    {
        PlayerPrefs.SetFloat("TotalPlaytime", totalPlaytime);
        PlayerPrefs.Save();
    }

    public void LoadPlaytime()
    {
        totalPlaytime = PlayerPrefs.GetFloat("TotalPlaytime", 0);
    }

    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(totalPlaytime / 60);
        int seconds = Mathf.FloorToInt(totalPlaytime % 60);

        playtimeText.text = $"Playtime: <color=red>{minutes:00}:{seconds:00}</color>";

    }
}
