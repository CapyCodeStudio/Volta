using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public enum IAStates//Modelo de máquina de estado
{
    Chasing, Catch, Wandering, Die
}
public class Enemy : MonoBehaviour
{
    public float interactionDistance = 5;
    IAStates states = IAStates.Wandering;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit[] hit = new RaycastHit[10];
    RaycastHit h;
    //private Animator animator;
    private void Awake()
    {
        //animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        states = IAStates.Wandering;
    }
    void Update()
    {
        
        switch (states)
        {
            case IAStates.Wandering:
                //  animator.SetBool("Wandering", true);
              
                if (Physics.Linecast(transform.position, target.position, out h))
                {
                    if (h.collider.CompareTag("Player"))
                    {
                        states = IAStates.Chasing;
                    }
                }
                break;
            case IAStates.Chasing:
                // animator.SetBool("Chasing", true);
                agent.SetDestination(target.position);
                if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
                {
                    states = IAStates.Catch;
                }
               /* if (HP == 0)
                {
                    states = IAStates.Die;
                }*/

                break;
            case IAStates.Catch:
                
                //target.gameObject.SetActive(false);
                break;
            case IAStates.Die:

                
                break;
        }
        

    }
     
  
}