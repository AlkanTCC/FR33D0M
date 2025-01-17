using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Canvas shopCanvas;
    public Canvas canvas;
    //Gemaakt door: Zeineb

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            print("bye");
            shopCanvas.gameObject.SetActive(true);
            canvas.gameObject.SetActive(false);
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
