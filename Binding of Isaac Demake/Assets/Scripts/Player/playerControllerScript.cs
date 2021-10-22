using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllerScript : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;

    private readonly float deadzoneValue = 0.5f;

    private PlayerStats playerStats;

    public enum PlayerDirection {UP, DOWN, LEFT, RIGHT};
    public PlayerDirection playerDirection = PlayerDirection.DOWN;

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
        playerStats = this.GetComponent<PlayerStats>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();

        // change sprites depending on movement input
        ChangeSprite();
    }

    private void Move()
    {
        // cache values for movement input
        Vector2 movementValues = movement.ReadValue<Vector2>();

        if (movementValues.x <= -deadzoneValue)
        {
            playerDirection = PlayerDirection.LEFT;
            this.transform.position += new Vector3(-1, 0, 0) * playerStats.GetSpeed() * Time.deltaTime;
        }
        else if (movementValues.x >= deadzoneValue)
        {
            playerDirection = PlayerDirection.RIGHT;
            this.transform.position += new Vector3(1, 0, 0) * playerStats.GetSpeed() * Time.deltaTime;
        }
        else if (movementValues.y >= deadzoneValue)
        {
            playerDirection = PlayerDirection.UP;
            this.transform.position += new Vector3(0, 1, 0) * playerStats.GetSpeed() * Time.deltaTime;
        }
        else if (movementValues.y <= -deadzoneValue)
        {
            playerDirection = PlayerDirection.DOWN;
            this.transform.position += new Vector3(0, -1, 0) * playerStats.GetSpeed() * Time.deltaTime;
        }
    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = playerDirection switch
        {
            PlayerDirection.DOWN => sprites[0],
            PlayerDirection.UP => sprites[1],
            PlayerDirection.LEFT => sprites[2],
            PlayerDirection.RIGHT => sprites[3],
            _ => sprites[0],
        };
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
