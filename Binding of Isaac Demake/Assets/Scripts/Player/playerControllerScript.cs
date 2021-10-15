using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllerScript : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();

        playerInputActions.Player.Action.performed += DoAction;
        playerInputActions.Player.Action.Enable();
    }

    private void DoAction(InputAction.CallbackContext obj)
    {
        //throw new NotImplementedException();
        Debug.Log("complete action");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Action.Disable();
    }
}
