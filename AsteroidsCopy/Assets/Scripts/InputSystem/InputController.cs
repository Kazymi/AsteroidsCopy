using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputController : MonoBehaviour, IMovementInput, IWeaponInput
{
    [SerializeField] private InputActionReference movementReference;
    [SerializeField] private InputActionReference shotReference;
    [SerializeField] private InputActionReference laserReference;

    public Vector2 MovementVector { get; private set; }


    public event Action callShot;
    public event Action callLaser;

    private void Update()
    {
        UpdateInput();
    }

    private void OnEnable()
    {
        shotReference.action.started += CallShot;
        laserReference.action.started += CallLaser;
        
        ServiceLocator.Subscribe<IMovementInput>(this);
        ServiceLocator.Subscribe<IWeaponInput>(this);
    }

    private void OnDisable()
    {
        shotReference.action.started -= CallShot;
        laserReference.action.started -= CallLaser;
        
        ServiceLocator.Unsubscribe<IMovementInput>();
        ServiceLocator.Unsubscribe<IWeaponInput>();
    }

    private void CallShot(InputAction.CallbackContext callbackContext)
    {
        callShot?.Invoke();
    }

    private void CallLaser(InputAction.CallbackContext callbackContext)
    {
        callLaser?.Invoke();
    }

    private void UpdateInput()
    {
        MovementVector = movementReference.ToInputAction().ReadValue<Vector2>();
    }
}