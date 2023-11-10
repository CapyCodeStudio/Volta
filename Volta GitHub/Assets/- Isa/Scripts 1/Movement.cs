using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform cam;
    public Animator animator;

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
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        JumpForce();
        GravityForce();
    

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
        animator.SetBool("Walk", horizontal != 0 || vertical != 0);

        //Correr
        if (Input.GetButton("Fire3") && Input.GetButton("Vertical")|| Input.GetButton("Fire3") && Input.GetButton("Horizontal"))
        {
            animator.SetBool("Walk", false);
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
       /* if (Input.GetButton("Fire2") && Input.GetButton("Vertical") || Input.GetButton("Fire2") && Input.GetButton("Horizontal"))
        {
            
            animator.SetBool("Walk", false);
            animator.SetBool("Crouch Walk", true);
        }
        else
        {
            animator.SetBool("Crouch Walk", false);
        }     */
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
        if (Time.timeScale == 1)
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
        } else
        {
            jumpForce = Vector3.zero;
        }
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