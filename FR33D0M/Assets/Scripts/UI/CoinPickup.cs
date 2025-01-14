using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    // Gemaakt door Roni
    [SerializeField] private int coinCount = 0; 

    [SerializeField] private TMP_Text coinText; 

    private void Start()
    {
        UpdateCoinUI(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")) 
        {
            coinCount++; 
            UpdateCoinUI(); 
            Destroy(collision.gameObject); 
        }
    }


    private void UpdateCoinUI()
    {
        coinText.text = "<color=#87CEEB>$" + coinCount.ToString("D8") + "</color>";
    }

}
