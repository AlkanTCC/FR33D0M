using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

// gemaakt door Jin aljumaili
public class Bullet : MonoBehaviour
{

    public GameObject damagePreFab1,damagePreFab2, damagePreFab3, damagePreFabCrit, enemy;
    TextMeshPro textMesh;
    [SerializeField] Rigidbody2D rb;
    TakeDamage takeDamage;
    PlayerShoot playerShoot;
    Vector2 position;
    public bool enemyHit = false;
    GameObject player;
    int totalDamage;
    bool isCrit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        enemy = FindFirstObjectByType<TakeDamage>().gameObject;
        takeDamage = FindFirstObjectByType<TakeDamage>();
        playerShoot = FindFirstObjectByType<PlayerShoot>();
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (CriticalHit())
            {
                totalDamage = playerShoot.currentWeapon.damage * playerShoot.currentWeapon.critDmg;
                takeDamage.HP -= totalDamage;
                print("Criticalstrike");
                GameObject damageInstanceCrit = Instantiate(damagePreFabCrit, enemy.transform);
                damageInstanceCrit.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = totalDamage.ToString();
            }
            else
            {
            takeDamage.HP -= playerShoot.currentWeapon.damage;
            GameObject damageInstance = Instantiate(GetPopUp(), enemy.transform);
            damageInstance.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = playerShoot.currentWeapon.damage.ToString();
            }
            gameObject.SetActive(false);
        }
    }
    private bool CriticalHit()
    {
        int criticalHit = Random.Range(0, 100);
        if (criticalHit < playerShoot.currentWeapon.critRate) return true;
        else
        {

        return false;
        }
    }
    private GameObject GetPopUp()
    {
        int random = Random.Range(0,3);
        if (random == 0)
        {
            return damagePreFab1;
        }
        else if (random == 1)
        {
            return damagePreFab2;
        }
        else
        {
            return damagePreFab3;
        } 
    }
   
  

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rb.linearVelocity = -(transform.up * 10);
        if (Vector2.Distance(playerShoot.firePoint.position, position) > playerShoot.currentWeapon.range)
        {
            //print("out of range");
            gameObject.SetActive(false);
        }
    }

    public void Rotation()
    {
        transform.rotation = player.transform.rotation;
    }
}
