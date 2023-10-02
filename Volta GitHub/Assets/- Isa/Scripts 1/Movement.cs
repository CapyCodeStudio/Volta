using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private AudioSource passosAudioSource;
    [SerializeField] private AudioClip[] passosAudioClip;

    [SerializeField] private AudioSource correrAudioSource;
    [SerializeField] private AudioClip[] correrAudioClip;

    [SerializeField] private AudioSource puloAudioSource;
    [SerializeField] private AudioClip[] puloAudioClip;

    public Transform cam;
    private Animator animator;

    public float moveSpeed = 5;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField] private float speedRun = 15;

    private CharacterController characterController;

    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float radiusChecker;

    [SerializeField] private float maxHeight;
    [SerializeField] private float timeToMaxHeight;
    private Vector3 jumpForce;
    private float jumpSpeed;
    private float gravity;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetGravity();
    }

    void Update()
    {

        JumpForce();
        GravityForce();
        Passos();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
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

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speedRun * Time.deltaTime);
            
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
           /* float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speedRun * Time.deltaTime);*/

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

           /* float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speedRun * Time.deltaTime);*/

        }
        else
        {
            animator.SetBool("RunR", false);
            
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
       if (animator.GetBool("Walk") || animator.GetBool("WalkL") || animator.GetBool("WalkR")) 
        {
            print("andando");
            passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
       }   
    }

    public void Correr()
    {
        correrAudioSource.PlayOneShot(correrAudioClip[Random.Range(0, correrAudioClip.Length)]);
    }

    public void Pulo()
    {
        correrAudioSource.PlayOneShot(correrAudioClip[Random.Range(0, correrAudioClip.Length)]);
    }

    private void SetGravity()
    {
        gravity = (2 * maxHeight) / Mathf.Pow(timeToMaxHeight, 2);
        jumpSpeed = gravity * timeToMaxHeight;
    }

    private void GravityForce()
    {
        jumpForce += gravity * Time.deltaTime * Vector3.down;
        characterController.Move(jumpForce);

        if (IsGrounded() == true) jumpForce = Vector3.zero;
    }

    private void JumpForce()
    {
        if (IsGrounded() == true)
        {
            if (Input.GetButton("Jump"))
            {
                jumpForce = jumpSpeed * Vector3.up;
                characterController.Move(jumpForce);

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