/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum IAStates
{
    Idle, Attack, Wandering, Die
}
public class Enemy : MonoBehaviour
{
    //public float interactionDistance = 5;
    IAStates states = IAStates.Idle;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit[] hit = new RaycastHit[10];
    RaycastHit h;
    //public Slider healthSlider;
    //public Text healthText;
    public int vida = 100;
    public int vidaAtual;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        states = IAStates.Idle;
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
            case IAStates.Idle:
               // animator.SetBool("Idle", true);
               *//* if (h.collider.CompareTag("Player"))
                {
                    states = IAStates.Wandering;
                }*/

/*  if (Physics.Linecast(transform.position, target.position, out h))
  {
      if (h.collider.CompareTag("Player"))
      {
          states = IAStates.Wandering;
      }


  }*//*
  break;
case IAStates.Wandering:
  animator.SetBool("Wandering", true);
  if (Physics.Linecast(transform.position, target.position, out h))
  {
      if (h.collider.CompareTag("Player"))
      {
          states = IAStates.Attack;
      }


  }
  break;
case IAStates.Attack:
  animator.SetBool("Attack", true);

  if (agent.remainingDistance <= agent.stoppingDistance && agent.hasPath)
  {

      agent.SetDestination(target.position);
  }
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
states = IAStates.Die;

}
}

private void UpdateHealthUI()
{
//healthSlider.value = (float)vidaAtual / vida; // slider
//healthText.text = "Health: " + vidaAtual + " / " + vida; // texto
}

private void OnTriggerEnter(Collider other)
{

if (other.CompareTag("Espadao"))
{
TakeDamage(10);
}
if (other.CompareTag("Attack"))
{
animator.SetBool("Attack", true);
}
else
{
animator.SetBool("Attack", false);
}

}


}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum IAStates
{
    Idle, Chasing, Catch, Wandering
}
public class Enemy : MonoBehaviour
{
    public float interactionDistance = 5;
    IAStates states = IAStates.Idle;
    NavMeshAgent agent;
    public Transform target;
    RaycastHit[] hit = new RaycastHit[3];
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
            case IAStates.Wandering:
                agent.SetDestination(target.position);
                break;
            case IAStates.Idle:
                if (Physics.Raycast(transform.position, transform.forward, out hit[0], interactionDistance))
                {
                    if (hit[0].collider.gameObject.CompareTag("Player"))
                    {
                        states = IAStates.Chasing;
                    }

                }
                if (Physics.Raycast(transform.position, new Vector3(transform.forward.x, transform.forward.y, transform.forward.z * 45), out hit[1], interactionDistance))
                {
                    if (hit[1].collider.gameObject.CompareTag("Player"))
                    {
                        states = IAStates.Chasing;
                    }

                }
                if (Physics.Raycast(transform.position, new Vector3(transform.forward.x, transform.forward.y, transform.forward.z - 45), out hit[2], interactionDistance))
                {
                    if (hit[2].collider.gameObject.CompareTag("Player"))
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