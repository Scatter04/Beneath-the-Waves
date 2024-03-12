using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private CharacterController myCC;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;

    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = 9.81f;

    private bool canMove = true;

    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
    }

    void GetInput()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxisRaw("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxisRaw("Horizontal") : 0;
        float movementDirectionY = movementVector.y;

        movementVector = (forward * curSpeedX) + (right * curSpeedY);

        // Jumping
        if (Input.GetButton("Jump") && canMove && myCC.isGrounded)
        {
            movementVector.y = jumpPower;
        }
        else
        {
            movementVector.y = movementDirectionY;
        }

        // In the air
        if (!myCC.isGrounded)
        {
            movementVector.y -= myGravity * Time.deltaTime;
        }

        // Crouching
        if (Input.GetKey(KeyCode.R) && canMove)
        {
            myCC.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        else
        {
            myCC.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }
}
