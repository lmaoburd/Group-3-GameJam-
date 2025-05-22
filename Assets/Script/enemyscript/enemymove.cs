using UnityEngine;
using UnityEngine.AI;

public class enemymove : MonoBehaviour
{
    public GameObject platform;      
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPosition();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            GoToRandomPosition();
        }
    }

    void GoToRandomPosition()
    {
        Vector3 randomPoint = GetRandomPointOnPlane();

       
        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 2f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    Vector3 GetRandomPointOnPlane()
    {
        Renderer renderer = platform.GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y;

        return new Vector3(x, y, z);
    }
}
