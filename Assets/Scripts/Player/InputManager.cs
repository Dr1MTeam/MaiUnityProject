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
    private PlayerAttack pAttack;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        walking = playerInput.Walking;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        pAttack = GetComponent<PlayerAttack>();
        walking.Jump.performed += ctx => motor.Jump();
        walking.Click.performed += ctx => pAttack.ProcessAttack();
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
