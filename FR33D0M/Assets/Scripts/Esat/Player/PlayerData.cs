using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    // Script gemaakt door Esat Yavuz

    public PlayerStats playerStats;

    private string playerStatsFile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerStatsFile = Application.persistentDataPath + "pStatsFile.json";

        if (!File.Exists(playerStatsFile)) 
        {
            playerStats = new PlayerStats(); // Struct krijgt waarde van een nieuwe struct
            CreateDataFile();
        }
        else 
        {
            LoadDataFile();
        }
        //InvokeRepeating("SaveGame", 5, 5);
    }

    void SaveGame()
    {
        string json = JsonUtility.ToJson(playerStats); 
    }

    private void CreateDataFile()
    {
        string json = JsonUtility.ToJson(playerStats);
        File.WriteAllText(playerStatsFile, json);
    }

    private void LoadDataFile()
    {
        string json = File.ReadAllText(playerStatsFile); 
        playerStats = JsonUtility.FromJson<PlayerStats>(json); 
    }
}

public struct PlayerStats
{
    public int playerMoney;
    public int playerHP;
    public int playerArmor;
    public Vector2 playerLocation;
}