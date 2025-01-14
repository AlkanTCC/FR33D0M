using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent agent;
    Rigidbody2D rb;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody2D>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DriveCarSystem>() != null)
        {
            print("daw");
            rb.AddForce(transform.up * collision.gameObject.GetComponent<DriveCarSystem>().currentSpeed * 1000);
        }
    }*/

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DriveCarSystem>() != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}