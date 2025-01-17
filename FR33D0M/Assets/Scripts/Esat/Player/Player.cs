using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Script gemaakt door Esat Yavuz

    [SerializeField] TextMeshProUGUI moneyTMP;
    [SerializeField] TextMeshProUGUI hpTMP;
    [SerializeField] TextMeshProUGUI armorTMP;

    private int playerMoney = 0;
    private int playerHP = 100;
    private int playerArmor = 0;

    private Vector2 playerLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moneyTMP.text = $"${playerMoney}";
        hpTMP.text = $"{playerHP}";
        armorTMP.text = $"{playerArmor}";
        playerLocation = transform.position;
    }

    public void AddMoney(int moneyAdded)
    {
        playerMoney += moneyAdded;
    }
}
