using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction movementActions;

    public Vector2 MovementDirection { get; private set; }
    private void OnEnable()
    {
        movementActions.Enable();
    }

    private void OnDisable()
    {
        movementActions.Disable();
    }

    private void Update()
    {
        UpdateMovementDirection();
    }

    private void UpdateMovementDirection()
    {
        MovementDirection = movementActions.ReadValue<Vector2>();
    }
}
