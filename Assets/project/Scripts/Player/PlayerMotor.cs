using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 PlayerVelocity;
    private bool IsGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = controller.isGrounded;
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
        // вот тут
        PlayerVelocity.y += gravity * Time.deltaTime;
        if (IsGrounded && PlayerVelocity.y < 0)
            PlayerVelocity.y = -2.0f;

        controller.Move(PlayerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (IsGrounded)
        {
            PlayerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }
    
    public void Crouch()
    {

    }
    public void Sprint()
    {

    }
}
