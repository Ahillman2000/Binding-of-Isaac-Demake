using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Item Pool")]
    public List<GameObject> itemsToSpawn = new List<GameObject>();
    //public GameObject itemsToSpawn;

    [Header("Randomised Items")]
    public bool isRandomized;


    // Start is called before the first frame update
    void Start()
    {
        int index = isRandomized ? Random.Range(0, itemsToSpawn.Count) : 0;

        if(itemsToSpawn.Count > 0)
        {
            Instantiate(itemsToSpawn[index], transform.position, Quaternion.identity);
        }
    }

    /*Use this to spawn the item in the spessific item room once we get that working
     * 
    public void ItemSpawn()
    {
        Instantiate(itemsToSpawn, transform.position, Quaternion.identity);
    }
    */
}
