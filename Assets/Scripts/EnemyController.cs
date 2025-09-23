using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    private NavMeshAgent agent;
    private Vector3 randomDirection;
    private float changeDirectionTimer;
    private float minChange = 3f;
    private float maxChange = 8f;
    private float range = 25f;
    private float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 5f)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            changeDirectionTimer -= Time.deltaTime;
            if (changeDirectionTimer <= 0f)
            {
                ChangeDirection();
            }
            agent.SetDestination(transform.position + randomDirection);
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= range)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player);
        }
    }

    void ChangeDirection()
    {
        randomDirection = Random.insideUnitSphere * 10f;
        changeDirectionTimer = Random.Range(minChange, maxChange);
    }
}
