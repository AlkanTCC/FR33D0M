using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    //Gemaakt door: Zeineb
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("gujzzvj");
        }
    }
}
