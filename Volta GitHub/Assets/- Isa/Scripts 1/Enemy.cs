using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public enum IAStates//Modelo de máquina de estado
{
    Idle, Chasing, Catch, Attack
}
public class Enemy : MonoBehaviour
{
    public float interactionDistance = 10;
    public float attackDistance = 5;
    public float vidaPlayer = 10;
    IAStates states = IAStates.Idle;
    NavMeshAgent agent;
    public Transform target;

    RaycastHit[] hit;
    RaycastHit h;
    [SerializeField] private GameObject menuPerdeu;

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
                print("Idle");
                if (Physics.Linecast(transform.position, target.position, out h))
                {
                    if (h.collider.CompareTag("Player"))
                    {
                       states = IAStates.Chasing;
                       
                    }

                }
                break;
            case IAStates.Chasing:
                print("Chasing");
                agent.SetDestination(target.position);
                if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
                {
                    states = IAStates.Catch;
                }
                break;
            case IAStates.Attack:
                break;
            case IAStates.Catch:
                print("Catch");
                target.gameObject.SetActive(false);
                break;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            menuPerdeu.SetActive(true);
        }

    }
}