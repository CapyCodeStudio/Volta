using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private Animator animator;

    public float runMultiplier = 2f;

    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
   
        // Movimentação horizontal e vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Vertical"))
        {
            animator.SetBool("Walk", true);
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false );
        }

        // Direção de movimento relativa à câmera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDirection = forward * verticalInput + right * horizontalInput;

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
        moveDirection.y -= 0 * Time.deltaTime; // Use um valor apropriado para a gravidade

        // Verificar se o jogador está correndo
        bool isRunning = Input.GetButton("Fire3");

        if (isRunning)
        {
            moveDirection *= runMultiplier;
            animator.SetBool("Run", isRunning);
        }

        // Movimentar o personagem
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Atualizar parâmetros do Animator
        float moveMagnitude = new Vector2(horizontalInput, verticalInput).sqrMagnitude;
        animator.SetFloat("Walk", moveMagnitude);
        animator.SetBool("Run", isRunning);

    }
}