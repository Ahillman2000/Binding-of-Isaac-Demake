using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllerScript : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private PlayerScript playerScript;

    enum PlayerDirection {UP, DOWN, LEFT, RIGHT};
    PlayerDirection playerDirection = PlayerDirection.DOWN;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.Enable();
    }

    void Start()
    {
        playerScript = this.GetComponent<PlayerScript>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // cache values for movement input
        Vector2 movementValues = movement.ReadValue<Vector2>();

        if (movementValues.x == -1)
        {
            playerDirection = PlayerDirection.LEFT;
        }
        else if (movementValues.x == 1)
        {
            playerDirection = PlayerDirection.RIGHT;
        }
        else if (movementValues.y == 1)
        {
            playerDirection = PlayerDirection.UP;
        }
        else if (movementValues.y == -1)
        {
            playerDirection = PlayerDirection.DOWN;
        }
        
        this.transform.position += new Vector3(movementValues.x, movementValues.y, 0) * playerScript.GetSpeed() * Time.deltaTime;

        // change sprites depending on movement input
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        switch (playerDirection)
        {
            case PlayerDirection.DOWN:
                spriteRenderer.sprite = sprites[0];
                break;
            case PlayerDirection.UP:
                spriteRenderer.sprite = sprites[1];
                break;
            case PlayerDirection.LEFT:
                spriteRenderer.sprite = sprites[2];
                break;
            case PlayerDirection.RIGHT:
                spriteRenderer.sprite = sprites[3];
                break;
            default:
                spriteRenderer.sprite = sprites[0];
                break;
        }
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
