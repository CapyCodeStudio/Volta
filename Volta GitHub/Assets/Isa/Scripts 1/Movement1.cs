
using static UnityEditor.ShaderData;
using System;
using Unity.VisualScripting;
using UnityEngine;
public class Movement1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    public float runMultiplier = 2f;
    private Animator animator;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        // Verifica se o jogador está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Movimentação
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        if (Input.GetButton("Fire3")) // Botão de corrida
        {
            move *= runMultiplier;
        }
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Pulo
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }

        // Gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        animator.SetBool("isWalking", move.magnitude > 0 && !Input.GetButton("Fire3"));
        animator.SetBool("isRunning", move.magnitude > 0 && Input.GetButton("Fire3"));
        animator.SetBool("isJumping", !isGrounded);
    }
}










