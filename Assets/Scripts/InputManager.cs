using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.WalkingActions walking;

    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        walking = playerInput.Walking;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        walking.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        look.ProcessLook(walking.Look.ReadValue<Vector2>());
        motor.ProcessMove(walking.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        walking.Enable();
    }
    private void OnDisable()
    {
        walking.Disable();
    }
}
