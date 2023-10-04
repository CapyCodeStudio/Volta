using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulhar : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int wayPointIndex;
    [SerializeField]Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 2)
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[wayPointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == waypoints.Length)
        {
            wayPointIndex = 0;
        }
        
    }
}
