using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private PlayerMover playerMover;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    private void Update()
    {
        Vector2 input = inputActions.Gameplay.Movement.ReadValue<Vector2>();
        playerMover.Move(input);
    }
}