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

    private GameObject player;
    private PlayerStats playerStats;

    private float nextFire = 0f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Action.performed += DoAction;
        playerInputActions.Player.Action.Enable();
    }

    private void DoAction(InputAction.CallbackContext obj)
    {
        //Debug.Log("Action Done");
        if (playerStats.GetFireRate() == 0)
        {
            FireTear();
        }
        else
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + playerStats.GetFireRate();
                FireTear();
            }
        }
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
