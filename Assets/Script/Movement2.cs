using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] int speed = 5;
    private float vertical_input;
    private float horizontal_input;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        vertical_input = Input.GetAxisRaw("Vertical");
        horizontal_input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(-vertical_input, 0f, horizontal_input).normalized;
        Vector3 isometricDirection = Quaternion.Euler(0, 45, 0) * inputDirection;
        rb.velocity = new Vector3(isometricDirection.x * speed, rb.velocity.y, isometricDirection.z * speed);
    }
}
