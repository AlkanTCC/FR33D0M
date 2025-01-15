using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Canvas shopCanvas;
    //Gemaakt door: Zeineb

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            print("bye");
            shopCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            print("hi");
            shopCanvas.gameObject.SetActive(false);
        }*/
    }
}
