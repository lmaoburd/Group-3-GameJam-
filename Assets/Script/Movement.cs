using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject cam1;
    public GameObject cam2;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Hit: " + hit.gameObject.name);

        if (hit.gameObject.CompareTag("House"))
        {
            Debug.Log("Entering house...");
            cam1.SetActive(false);
            cam2.SetActive(true);
            controller.enabled = false; 
            transform.position = new Vector3(4, 18, -215);
            controller.enabled = true;
        }

        if (hit.gameObject.CompareTag("door"))
        {
            Debug.Log("Exiting house...");
            cam1.SetActive(true);
            cam2.SetActive(false);
            controller.enabled = false;
            transform.position = new Vector3(12, 3, -12);
            controller.enabled = true;
        }
    }
}
