using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private int menuOption = 0;

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
        //Debug.Log("Play Game");

        PlayGame();
    }

    void Update()
    {
        float yInput = movement.ReadValue<Vector2>().y;
        
        if (yInput > 0)
        {

        }
        else if (yInput < 0)
        {

        }
        Debug.Log(yInput);
    }

    public void PlayGame()
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
