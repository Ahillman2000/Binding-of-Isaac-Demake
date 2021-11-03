using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombSpawner : MonoBehaviour
{
    GameObject player;
    public GameObject bombToSpawn;
    private BombDestructor bombDestructor;

    PlayerItems playerItems;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Bomb.performed += SpawnBomb;
        playerInputActions.Player.Bomb.Enable();
    }

    void Start()
    {
        bombDestructor = bombToSpawn.GetComponent<BombDestructor>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerItems = player.GetComponent<PlayerItems>();

    }
    void Update()
    {
        if (playerItems.GetBombs() == 0)
        {

        }

        /*(if (playerItems.GetBombs() > 0)
        {
            OnEnable();
        }
        else
        {
            OnDisable();
        }*/
       
    }


    private void SpawnBomb(InputAction.CallbackContext obj)
    {
        if (playerItems.GetBombs() > 0)
        {
            Instantiate(bombToSpawn, transform.position, Quaternion.identity);
            bombDestructor.isExploded = true;
            playerItems.SetBombs(playerItems.GetBombs() - 1);
        }
    }
    
    void BombExplode()
    {

    }

    private void OnDisable()
    {
        playerInputActions.Player.Bomb.Disable();
    }
}
