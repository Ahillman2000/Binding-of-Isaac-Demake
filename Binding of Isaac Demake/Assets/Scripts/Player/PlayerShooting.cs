using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public GameObject tearsPrefab;
    public Transform firePoint; 

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Action.performed += DoAction;
        playerInputActions.Player.Action.Enable();
    }

    private void DoAction(InputAction.CallbackContext obj)
    {
        //Debug.Log("Action Done");

        FireTear();
    }

    private void FireTear()
    {
        Instantiate(tearsPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDisable()
    {
        playerInputActions.Player.Action.Disable();
    }
}
