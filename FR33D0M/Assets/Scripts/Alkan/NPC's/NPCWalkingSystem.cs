using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.LightTransport;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class NPCWalkingSystem : MonoBehaviour
{
    Rigidbody2D rb;
    NPCManager npcManager;
    NavMeshAgent agent;
    NPC npc;

    NPCObject npcObject;
    List<Vector3Int> allTilePositions;

    Vector2 target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        npcManager = FindAnyObjectByType<NPCManager>();
        npc = GetComponent<NPC>();

        npcObject = Instantiate(npcManager.npcObjectArray[Random.Range(0, npcManager.npcObjectArray.Length)]);
        allTilePositions = npcManager.allTilePositions;

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = Random.Range((float)(npcObject.speed - 1), (float)(npcObject.speed + 1));

        npc.health = Random.Range(npcObject.health - 20, npc.health + 20);

        RandomStartLocation();
    }

    private void FixedUpdate()
    {
        if (npc.health > 0)
        {
            if (agent != null)
            {
                if (npcObject.civilian) Civillian();
                else if (npcObject.enemy) Enemy();
            }

            if (Mathf.Abs(rb.linearVelocity.x) <= 0.5f && Mathf.Abs(rb.linearVelocity.y) <= 0.5f && !agent.enabled) agent.enabled = true;
            if (agent.enabled) rb.linearVelocity = Vector2.zero;
        }
    }

    void Civillian()
    {
        if (agent.enabled && npc.health > 0) agent.SetDestination(target);
        RotateToTarget();

        if (IsAtTarget()) ChooseRandomTargetLocation();
    }

    void Enemy()
    {

    }

    void RandomStartLocation()
    {
        Vector3Int randomTargetValue = allTilePositions[Random.Range(0, allTilePositions.Count)];
        transform.position = new Vector2(randomTargetValue.x + 0.5f, randomTargetValue.y + 0.5f);
    }

    void ChooseRandomTargetLocation()
    {
        Vector3Int randomTargetValue = allTilePositions[Random.Range(0, allTilePositions.Count)];
        target = new Vector2(randomTargetValue.x + 0.5f, randomTargetValue.y + 0.5f);
    }

    void RotateToTarget()
    {
        if (agent.enabled)
        {
            float angle = Mathf.Atan2(agent.velocity.y, agent.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        }
    }

    bool IsAtTarget()
    {
        float distance = 1f;

        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(target.x, target.y, 0)) < distance)
        {
            return true;
        }
        return false;
    }

    public void CarCollision(DriveCarSystem pDriveCarSystem)
    {
        agent.enabled = false;

        rb.AddForce(pDriveCarSystem.GetComponent<Rigidbody2D>().linearVelocity / 2, ForceMode2D.Impulse);
        npc.health -= (int)(pDriveCarSystem.currentSpeed * 5);
    }
}
