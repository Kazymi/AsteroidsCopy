using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputController : MonoBehaviour,IInputController
{
    [SerializeField] private InputAction movementActions;

    public Vector2 MovementVector { get; private set; }

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
        MovementVector = movementActions.ReadValue<Vector2>();
    }
}