using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    // Script gemaakt door Esat Yavuz

    Player player = null;

    bool moneyPickedUp = false;

    [SerializeField] float timeToDestroy = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
        InvokeRepeating("DestroyMoney", 30f, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (moneyPickedUp) return;
        else if (collision.gameObject == player.gameObject)
        {
            GivePlayerMoney();
            moneyPickedUp = true;
        }
    }

    void GivePlayerMoney()
    {
        int moneyAmount = Random.Range(20, 200);
        player.AddMoney(moneyAmount);
        InvokeRepeating("DestroyMoney", 0.1f, timeToDestroy);
    }

    void DestroyMoney()
    {
        if (transform.localScale.x < 0.1f) Destroy(gameObject);
        else transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);
    }
}
