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
    //public float interactionDistance = 5;
    IAStates states = IAStates.Wandering;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit[] hit = new RaycastHit[10];
    RaycastHit h;

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

                if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)

                {

                    states = IAStates.Catch;

                }

                break;

            case IAStates.Catch:

                target.gameObject.SetActive(false);

                break;

        }


    }

}


