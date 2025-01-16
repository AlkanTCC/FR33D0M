using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public Image weaponUIImage; 
    public Sprite defaultWeaponSprite; 
    public Sprite pistolSprite; 
    public Sprite rifleWeaponSprite; 
    public Sprite akmSprite; 
    public Sprite grenadeSprite;

    private void Start()
    {
        
        if (weaponUIImage != null)
        {
            weaponUIImage.sprite = defaultWeaponSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Weapon"))
        {
            
            switch (other.name)
            {
                case "Pistol":
                    weaponUIImage.sprite = pistolSprite;
                    break;
                case "RifleWeapon":
                    weaponUIImage.sprite = rifleWeaponSprite;
                    break;
                case "AKM":
                    weaponUIImage.sprite = akmSprite;
                    break;
                case "Grenade":
                    weaponUIImage.sprite = grenadeSprite;
                    break;
                default: 
                    weaponUIImage.sprite = defaultWeaponSprite;
                    break;
            }

            
            Destroy(other.gameObject);
        }
    }
}
