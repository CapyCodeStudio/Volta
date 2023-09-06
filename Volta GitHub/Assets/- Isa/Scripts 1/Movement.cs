using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float gravity;

    [SerializeField]
    private float maximumSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private Transform cameraTransform;

    private int moveSpeed = 5;

    private Animator animator;
    //private Rigidbody body;
    private CharacterController characterController;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //body = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButton("Vertical"))
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetButton("Fire3") && Input.GetButton("Vertical") || Input.GetButton("Fire3") && Input.GetButton("Horizontal"))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("Run", true);
            maximumSpeed = 20;
        }
        else
        {
            animator.SetBool("Run", false);
            maximumSpeed = 10;
        }

        if (Input.GetButton("Fire3") && Input.GetButton("A"))
        {
            animator.SetBool("WalkL", false);
            animator.SetBool("RunL", true);
            maximumSpeed = 20;
        }
        else
        {
            animator.SetBool("RunL", false);
            maximumSpeed = 10;
        }

        if (Input.GetButton("Fire3") && Input.GetButton("D"))
        {
            animator.SetBool("WalkR", false);
            animator.SetBool("RunR", true);
            maximumSpeed = 20;
        }
        else
        {
            animator.SetBool("RunR", false);
            maximumSpeed = 10;
        }

        if (Input.GetButton("D"))
        {
            animator.SetBool("WalkR", true);
        }
        else
        {
            animator.SetBool("WalkR", false);
        }

        if (Input.GetButton("A"))
        {
            animator.SetBool("WalkL", true);
        }
        else
        {
            animator.SetBool("WalkL", false);
        }

        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (verticalInput * cameraForward + horizontalInput * cameraTransform.right).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            // Rotação
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500);

            // Movimentar o personagem
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