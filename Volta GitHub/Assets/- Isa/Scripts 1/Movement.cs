using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
   
    [SerializeField]
    private float maximumSpeed = 20;

    [SerializeField]
    private AudioSource passosAudioSource;

    [SerializeField]
    private AudioClip[] passosAudioClip;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform cameraTransform;

    private int moveSpeed = 10;

    private Animator animator;
    private Rigidbody body;
    private CharacterController characterController;

    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float radiusChecker;

    [SerializeField] private float maxHeight;
    [SerializeField] private float timeToMaxHeight;
    private Vector3 _yJumpForce;
    private float _jumpSpeed;
    private float _gravity;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        SetGravity();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        JumpForce();
        GravityForce();

        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 SimplemoveDirection = (verticalInput * cameraForward + horizontalInput * cameraTransform.right).normalized;

        if (SimplemoveDirection.magnitude > 0.1f)
        {
            // Rotação
            Quaternion targetRotation = Quaternion.LookRotation(SimplemoveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 500);

            // Movimentar o personagem
            Vector3 SimpleMove = SimplemoveDirection * moveSpeed * Time.deltaTime;
            transform.position += SimpleMove;


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
            Vector3 SimpleMove = SimplemoveDirection * maximumSpeed * Time.deltaTime;
            transform.position += SimpleMove;

        }
        else
        {
            animator.SetBool("Run", false);
            /*Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.position += move;*/

        }

        if (Input.GetButton("Fire3") && Input.GetButton("A") || Input.GetButton("Fire3") && Input.GetButton("Left"))
        {

            animator.SetBool("Walk", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("RunL", true);
            Vector3 move = SimplemoveDirection * maximumSpeed * Time.deltaTime;
            transform.position += move;
        }
        else
        {
            animator.SetBool("RunL", false);
            /*Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
            transform.position += move;*/
        }

        if (Input.GetButton("Fire3") && Input.GetButton("D") || Input.GetButton("Fire3") && Input.GetButton("Right"))
        {

            animator.SetBool("Walk", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("RunR", true);
            Vector3 move = SimplemoveDirection * maximumSpeed * Time.deltaTime;
            transform.position += move;
        }
        else
        {
            animator.SetBool("RunR", false);
            /* Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
             transform.position += move;*/
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

    
    public void Passos()
    {
       passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
    }

    private void SetGravity()
    {
        _gravity = (2 * maxHeight) / Mathf.Pow(timeToMaxHeight, 2);
        _jumpSpeed = _gravity * timeToMaxHeight;
    }

    private void GravityForce()
    {
        _yJumpForce += _gravity * Time.deltaTime * Vector3.down;
        characterController.Move(_yJumpForce);

        if (IsGrounded() == true) _yJumpForce = Vector3.zero;
    }

    private void JumpForce()
    {
        if (IsGrounded() == true)
        {
            if (Input.GetButton("Jump"))
            {
                _yJumpForce = _jumpSpeed * Vector3.up;
                characterController.Move(_yJumpForce);

                animator.SetBool("Jump", true);
            }
        }
        else animator.SetBool("Jump", false);
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.CheckSphere(groundChecker.position, radiusChecker, layerGround);
        return isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundChecker.position, radiusChecker);
    }



}