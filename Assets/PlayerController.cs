using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 80.0f;

    public Camera playerCamera;
    public Transform ball;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    private int multiplier = 1;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("zone1"))
        {
            multiplier = 1;
        }
        
        if (other.CompareTag("zone2"))
        {
            multiplier = 2;
        }
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleThrow();
    }

    void HandleThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var instantiatedBall = Instantiate(ball, ball.position, ball.rotation);
            instantiatedBall.gameObject.SetActive(true);
            
            instantiatedBall.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * 1200);
            instantiatedBall.GetComponent<BallController>().multiplier = multiplier;
        }
    }

    void HandleMovement()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        float curSpeedX = walkingSpeed * Input.GetAxis("Vertical");
        float curSpeedY = walkingSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
