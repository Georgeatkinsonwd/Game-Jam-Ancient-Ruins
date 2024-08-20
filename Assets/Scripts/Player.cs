using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }


    private Vector3 velocity;
    private Vector3 PlayerMovementInput;
    [SerializeField] private bool isPlayerAlive = true;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float turnSpeed;
    [SerializeField] public bool hasKey = false;
    [SerializeField] private bool isGrounded;
    private Animator animator;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    void Start()
    {
        animator = GetComponent<Animator>();



    }

    void Update()
    {
        if (!isPlayerAlive)
        {
            return;
        }

        MovePlayer();
        isGrounded = Controller.isGrounded;

    }


    void MovePlayer()
    {
        PlayerMovementInput = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        transform.Rotate(Vector3.up, turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (Controller.isGrounded)
        {

            velocity.y = -1f;


            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("isJumping", true);
                velocity.y = jumpForce;

            }
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);


        }
        animator.SetBool("isFalling", !Controller.isGrounded);
        Controller.Move(MoveVector * speed * Time.deltaTime);
        Controller.Move(velocity * Time.deltaTime);
        animator.SetBool("isRunning", PlayerMovementInput != Vector3.zero && Controller.isGrounded);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            isPlayerAlive = false;
            animator.SetBool("isFalling", false);
            animator.SetBool("isDying", !isPlayerAlive);
            Debug.Log("death");
        }
    }

}
