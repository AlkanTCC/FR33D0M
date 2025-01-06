using UnityEngine;

// Gemaakt door Jin aljumaili //
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up);
        if (hit == true)
        {
            Debug.Log("hit enemy");
        }
    }
}
