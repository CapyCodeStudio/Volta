using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public enum IAStates//Modelo de m�quina de estado
{
    Idle, Chasing, Catch
}
public class Enemy : MonoBehaviour
{
    public float interactionDistance = 5;
    IAStates states = IAStates.Idle;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit[] hit;
    RaycastHit h;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (states)
        {
            case IAStates.Idle:

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