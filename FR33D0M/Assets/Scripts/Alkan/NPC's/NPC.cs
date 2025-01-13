using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject blood;
    Animator animator;

    public int health;

    bool death = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0 && !death)
        {
            death = true;
            animator.SetBool("death", true);
            GameObject bloodObject = Instantiate(blood);
            bloodObject.transform.position = transform.position;
            GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<NPCWalkingSystem>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
