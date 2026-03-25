using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;


    [Header("Movement seetings")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpforce;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movementeDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

        if(Input.GetKeyDown(KeyCode.Space) && IsPlayerOnGround())
        {
            Jump();
        }

        PlayerAnimation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput =Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        movementeDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.velocity = new Vector3(movementeDirection.x * moveSpeed, rb.velocity.y, movementeDirection.z * moveSpeed);
    }
    
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    }

    private void PlayerAnimation()
    {
        if(IsPlayerOnGround())
        {
            if(movementeDirection.magnitude > 0.1f)
            {
                animator.SetInteger("State", 1);
            }
            else
            {
                animator.SetInteger("State", 0);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetInteger("State", 2);
            }
        }
        else
        {
            animator.SetInteger("State", 3);
        }
    }

    private bool IsPlayerOnGround()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
    }
}
