using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
   
    [SerializeField]
    private float maximumSpeed;

    [SerializeField]
    private AudioSource passosAudioSource;

    [SerializeField]
    private float rotationSpeed;

    /*[SerializeField]
    private float jumpSpeed;
*/
    private bool estaNoChao;
    [SerializeField] private Transform veficadorChao;
    [SerializeField] private LayerMask cenarioMask;

    [SerializeField]
    private Transform cameraTransform;

    private int moveSpeed = 5;

    private Animator animator;
    private Rigidbody body;
    private CharacterController characterController;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (verticalInput * cameraForward + horizontalInput * cameraTransform.right).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            // Rota��o
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500);

            // Movimentar o personagem
            Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.position += move;


        }
        if (Input.GetButton("Vertical"))
        {
            animator.SetBool("Walk", true);

        }
        else
        {
            animator.SetBool("Walk", false);
        }



        if (Input.GetButton("D") || Input.GetButton("Right"))
        {
            animator.SetBool("WalkR", true);
        }
        else
        {
            animator.SetBool("WalkR", false);
        }

        if (Input.GetButton("A") || Input.GetButton("Left"))
        {
            animator.SetBool("WalkL", true);
        }
        else
        {
            animator.SetBool("WalkL", false);
        }
        if (Input.GetButton("Fire3") && Input.GetButton("Vertical")/* || Input.GetButton("Fire3") && Input.GetButton("Horizontal")*/)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("Run", true);
            Vector3 move = moveDirection * maximumSpeed * Time.deltaTime;
            transform.position += move;
            
        }
        else
        {
            animator.SetBool("Run", false);
            Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.position += move;

        }

        if (Input.GetButton("Fire3") && Input.GetButton("A") || Input.GetButton("Fire3") && Input.GetButton("Left"))
        {

            animator.SetBool("Walk", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("RunL", true);
            Vector3 move = moveDirection * maximumSpeed * Time.deltaTime;
            transform.position += move;
        }
        else
        {
            animator.SetBool("RunL", false);
            Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.position += move;
        }

        if (Input.GetButton("Fire3") && Input.GetButton("D") || Input.GetButton("Fire3") && Input.GetButton("Right"))
        {

            animator.SetBool("Walk", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("RunR", true);
            Vector3 move = moveDirection * maximumSpeed * Time.deltaTime;
            transform.position += move;
        }
        else
        {
            animator.SetBool("RunR", false);
            Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.position += move;
        }
        
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }


}