using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public Transform player;
    public Transform soundOverlap;
    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("soundoverlay"))
        {
            agent.SetDestination(other.transform.position);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("soundoverlay"))
        {
            agent.SetDestination(other.transform.position);
        }
    }
}
