using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void DestroyAnimation()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);

    }
}
