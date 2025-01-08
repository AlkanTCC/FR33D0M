using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; 
    [SerializeField] private int maxArmor = 100;  

    private int currentHealth; 
    private int currentArmor;  

    [SerializeField] private TMP_Text healthText; 
    [SerializeField] private TMP_Text armorText;  

    private void Start()
    {
        currentHealth = maxHealth;
        currentArmor = 0;

        UpdateHealthUI();
        UpdateArmorUI();
    }

    public void TakeDamage(int damage)
    {
        if (currentArmor > 0)
        {
            currentArmor -= damage;

            
            if (currentArmor < 0)
            {
                int leftoverDamage = Mathf.Abs(currentArmor); // Bereken resterende schade
                currentArmor = 0;
                currentHealth -= leftoverDamage; // Pas resterende schade toe op HP
            }
        }
        else
        {
            currentHealth -= damage; // Als geen armor, dan direct HP verminderen
        }

        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //Hier game over screen geladen
        }

        UpdateHealthUI();
        UpdateArmorUI();
    }

    public void PickUpArmor(int armorAmount)
    {
        currentArmor += armorAmount;

        // Zorg ervoor dat armor niet boven het maximum gaat
        if (currentArmor > maxArmor)
        {
            currentArmor = maxArmor;
        }

        UpdateArmorUI();
    }

    public void PickUpHealth(int healthAmount)
    {
        currentHealth += healthAmount;

        // Zorg ervoor dat HP niet boven het maximum gaat
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthText.text = " <color=red>" + currentHealth.ToString() + "</color>";
    }

    private void UpdateArmorUI()
    {
        armorText.text = " <color=green>" + currentArmor.ToString() + "</color>";
    }
}
