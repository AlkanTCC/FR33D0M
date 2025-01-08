using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; 
    private int currentHealth; 

    [SerializeField] private TMP_Text healthText; 

    private void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthUI();
    }


    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

    }

    
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    
    private void UpdateHealthUI()
    {
        healthText.text = "HP: <color=red>" + currentHealth.ToString() + "</color>";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp")) 
        {
            Heal(10); 
            Destroy(collision.gameObject); 
        }
    }
}
