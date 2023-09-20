using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed = 8, strafeSpeed = 5, gravityModifier = 5, interactionDistance = 5;

    Transform cam;//Objeto que carrega a posição da câmera para o raycast

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
    
        JumpForce();
        GravityForce();
        Controls();

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
           
        }
        else
        {
            animator.SetBool("Run", false);
           
        }

        if (Input.GetButton("Fire3") && Input.GetButton("A") || Input.GetButton("Fire3") && Input.GetButton("Left"))
        {

            animator.SetBool("Walk", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("RunL", true);
           
        }
        else
        {
            animator.SetBool("RunL", false);
            
        }

        if (Input.GetButton("Fire3") && Input.GetButton("D") || Input.GetButton("Fire3") && Input.GetButton("Right"))
        {

            animator.SetBool("Walk", false);
            animator.SetBool("WalkL", false);
            animator.SetBool("WalkR", false);
            animator.SetBool("RunR", true);
           
        }
        else
        {
            animator.SetBool("RunR", false);
            
        }
       
        
    }
    void Controls()
    {
    float forWardInput = Input.GetAxisRaw("Vertical");
    float strafeInput = Input.GetAxisRaw("Horizontal");

    Vector3 strafe = strafeInput * strafeSpeed * transform.right;
    Vector3 forward = forWardInput * forwardSpeed * transform.forward;
    Vector3 vertical = _gravity * Time.deltaTime * Vector3.up;

    Vector3 finalVelocity = forward + strafe + vertical;
    characterController.Move(finalVelocity * Time.deltaTime);
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