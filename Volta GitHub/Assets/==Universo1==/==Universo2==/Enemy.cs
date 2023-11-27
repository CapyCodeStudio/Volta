using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum IAStates
{
    Chasing, Catch, Wandering
}

public class Enemy : MonoBehaviour
{
    IAStates states = IAStates.Wandering;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit h;

    //bool hasCaughtPlayer = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        states = IAStates.Wandering;
        Animator animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (states)
        {
            case IAStates.Wandering:
                if (Physics.Linecast(transform.position, target.position, out h))
                {
                    if (h.collider.CompareTag("Player"))
                    {
                        states = IAStates.Chasing;
                    }
                }
                break;
            case IAStates.Chasing:
                agent.SetDestination(target.position);
               /* if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
                {
                    states = IAStates.Catch;
                }*/
                break;
           /* case IAStates.Catch:
              
                break;*/
        }
    }
   
}