using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum IAStates
{
    Chasing, Catch, Wandering, Die
}
public class Enemy : MonoBehaviour
{
    //public float interactionDistance = 5;
    IAStates states = IAStates.Wandering;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit[] hit = new RaycastHit[10];
    RaycastHit h;
    //public Slider healthSlider;
    //public Text healthText;
    private int vida = 100;
    private int vidaAtual;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        states = IAStates.Wandering;
    }
    private void Start()
    {
        vidaAtual = vida;
        UpdateHealthUI();

    }

    void Update()
    {
        
        switch (states)
        {
            case IAStates.Wandering:
                animator.SetBool("Wandering", true);
              
                if (Physics.Linecast(transform.position, target.position, out h))
                {
                    if (h.collider.CompareTag("Player"))
                    {
                        states = IAStates.Chasing;
                    }
                }
                break;
            case IAStates.Chasing:
                animator.SetBool("Chasing", true);
                agent.SetDestination(target.position);
                if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
                {
                    states = IAStates.Catch;
                }
               
                break;
            case IAStates.Catch:
                animator.SetBool("Catch", true);
                //target.gameObject.SetActive(false);
                break;
            case IAStates.Die:

                animator.SetBool("Die", true);
                break;
        }
        

    }
    public void TakeDamage(int damage)
    {
        vidaAtual -= damage; // dano
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vida);
        UpdateHealthUI();

        if (vidaAtual <= 0)
        {      
            states = IAStates.Chasing;
        }
    }

    private void UpdateHealthUI()
    {
        //healthSlider.value = (float)vidaAtual / vida; // slider
        //healthText.text = "Health: " + vidaAtual + " / " + vida; // texto
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            TakeDamage(10);
        }
    }
}