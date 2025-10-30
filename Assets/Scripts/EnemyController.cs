using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform player;
    private NavMeshAgent agent;
    private Vector3 randomDirection;
    private float changeDirectionTimer;
    private float minChange = 3f;
    private float maxChange = 8f;
    private float range = 20f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            agent.speed = 6;
            agent.SetDestination(player.position);
            animator.SetBool("isRun", true);
            animator.SetBool("isWalk", false);
        }
        else
        {
            changeDirectionTimer -= Time.deltaTime;

            if (changeDirectionTimer <= 0f)
            {
                ChangeDirection();
            }
            agent.speed = 3;
            agent.SetDestination(transform.position + randomDirection);

            animator.SetBool("isRun", false);
            animator.SetBool("isWalk", true);
        }
    }

    void ChangeDirection()
    {
        randomDirection = Random.insideUnitSphere * 10f;
        changeDirectionTimer = Random.Range(minChange, maxChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            agent.isStopped = true;
            animator.SetTrigger("Fall");
        }
    }
}
