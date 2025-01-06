using UnityEngine;

public class PlaytimeTracker
{
    private float totalPlaytime;

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

}
  