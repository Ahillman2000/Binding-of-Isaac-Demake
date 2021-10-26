using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LoseMenu : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Action.performed += DoAction;
        playerInputActions.Player.Action.Enable();

        movement = playerInputActions.Player.Movement;
        movement.Enable();
    }

    void Start()
    {

    }

    private void DoAction(InputAction.CallbackContext obj)
    {
        //Debug.Log("Select Option");

        Restart();
    }

    void Update()
    {
        Vector2 inputValues = movement.ReadValue<Vector2>();
        if (inputValues.y != 0)
        {
            Debug.Log(inputValues.y);
        }
    }

    void Restart() 
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Debug.Log("Quit application");
        Application.Quit();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Action.Disable();
        movement.Disable();
    }
}
