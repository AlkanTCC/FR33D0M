using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

// Gemaakt door Jin aljumaili //
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Weapons pistol;
    [SerializeField] Weapons sub;
    public Transform firePoint;
    [HideInInspector] public Weapons currentWeapon;
    BulletPool pool;
    bool shooting = false;
    bool reloading = false;
    int currentAmmoPistol;
    int currentAmmoSub;
    int currentAmmo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = FindFirstObjectByType<BulletPool>();
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
                if (currentWeapon != pistol)
                {
                    Debug.Log("pistol");
                    currentWeapon = pistol;
                }

                break;
            case "2":
                if (currentWeapon != sub)
                {
                    Debug.Log("submachine gun");
                    currentWeapon = sub;
                }
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
            if (bullet != null)
            {
                bullet.transform.position = firePoint.transform.position;
                bullet.SetActive(true);
            }
            currentAmmoPistol--;
        }
        if (currentWeapon == sub && currentAmmoSub > 0)
        {
            GameObject bullet = BulletPool.instance.GetGameObject();
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.SetActive(true);
                //bullet.GetComponent<Bullet>().AddForce();
            }
            currentAmmoSub--;
        }

    }
    IEnumerator Reloading()
    {
        if (currentAmmoPistol < pistol.ammo || currentAmmoSub < sub.ammo)
        {
             reloading = true;


            if (currentWeapon == pistol)
            {
                Debug.Log("reloading");
                yield return new WaitForSeconds((int)currentWeapon.reloadTime);
                Debug.Log("Reloaded");
                currentAmmoPistol = currentWeapon.ammo;
            }
            if (currentWeapon == sub)
            {
                Debug.Log("reloading");
                yield return new WaitForSeconds((int)currentWeapon.reloadTime);
                Debug.Log("Reloaded");
                currentAmmoSub = currentWeapon.ammo;
            }
        }
        else
        {
            print("Weapon is full");
        }
            reloading = false;


    }

}
