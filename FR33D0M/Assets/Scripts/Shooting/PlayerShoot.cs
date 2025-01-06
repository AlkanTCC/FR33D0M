using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// Gemaakt door Jin aljumaili //
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Weapons pistol;
    [SerializeField] Weapons sub;
    [SerializeField] GameObject bullet;
    Weapons currentWeapon;
    bool shooting = false;
    bool reloading = false;
    int currentAmmoPistol;
    int currentAmmoSub;
    int currentAmmo; // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmoPistol = pistol.ammo;
        currentAmmoSub = sub.ammo;

    }

    // Update is called once per frame
    void Update()
    {
        if (!reloading) SwitchWeapons();
        if (Input.GetKeyUp(KeyCode.R) && !reloading)
        {
            StartCoroutine(Reloading());
        }
        if (currentWeapon == pistol && Input.GetMouseButton(0) && !shooting && !reloading)
        {
            Shooting();
            shooting = true;
        }
        if (currentWeapon == sub && Input.GetMouseButtonDown(0) && !shooting && !reloading)
        {
            InvokeRepeating("Shooting", 0f, currentWeapon.fireRate);
            shooting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
            shooting = false;
        }
    }
    private void SwitchWeapons()
    {
        switch (Input.inputString)
        {
            case "1":
                Debug.Log("pistol");
                currentWeapon = pistol;

                break;
            case "2":
                Debug.Log("submachine gun");
                currentWeapon = sub;
                break;
            default:
                if (currentWeapon == null)
                {
                    currentWeapon = pistol;
                }
                break;
        }
    }
    private void Shooting()
    {
        if (currentWeapon == pistol && currentAmmoPistol > 0)
        {
            GameObject bullet = BulletPool.instance.GetGameObject();
            if (bullet == null)
            {
                bullet.transform.position = firePoint.position;
                bullet.SetActive(true);
            }
            currentAmmoPistol--;
            Debug.Log(currentAmmoPistol);
        }
        if (currentWeapon == sub && currentAmmoSub > 0)
        {
            // Instantiate(bullet, firePoint.position, firePoint.rotation);
            GameObject bullet = BulletPool.instance.GetGameObject();
            if (bullet == null)
            {
                bullet.transform.position = firePoint.position;
                bullet.SetActive(true);
            }
            currentAmmoSub--;
            Debug.Log(currentAmmoSub);
        }

    }
    IEnumerator Reloading()
    {
        if (currentAmmoPistol != pistol.ammo || currentAmmoSub != sub.ammo)
        {
             reloading = true;


            if (currentWeapon == pistol)
            {
                Debug.Log("reloading");
                yield return new WaitForSeconds((int)currentWeapon.reloadTime);
                Debug.Log("Reloaded");
                currentAmmoPistol = currentWeapon.ammo;
                //eloading = false;
            }
            if (currentWeapon == sub)
            {
                Debug.Log("reloading");
                yield return new WaitForSeconds((int)currentWeapon.reloadTime);
                Debug.Log("Reloaded");
                currentAmmoSub = currentWeapon.ammo;
                //reloading = false;
            }
        }
            reloading = false;


    }

}
