using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform soundOverlap;
    NavMeshAgent agent;
    bool chasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("sound"))
        {
            agent.SetDestination(other.transform.position);
            chasing = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("sound"))
        {
            agent.SetDestination(other.transform.position);

        }
    }
}
