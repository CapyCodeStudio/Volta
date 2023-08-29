using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float rotationSpeed = 2.0f;
    public Animator animator;

    private CharacterController characterController;
    private Vector3 moveDirection;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
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
            animator.SetBool("Run", true);
            moveSpeed = 10;
        }
        else
        {
            animator.SetBool("Run", false);
            moveSpeed = 5;
        }

        // Movimentação horizontal e vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Direção de movimento relativa à câmera
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0; // Garantir que o movimento seja horizontal apenas
        cameraRight.y = 0;
        Vector3 moveDirection = (cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput).normalized;


        // Rotação do personagem para a direção de movimento
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;

        // Pular
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }
        }
        
        // Aplicar gravidade
        moveDirection.y -= 9.81f * Time.deltaTime;

        // Movimentar o personagem
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);  
    }

}

