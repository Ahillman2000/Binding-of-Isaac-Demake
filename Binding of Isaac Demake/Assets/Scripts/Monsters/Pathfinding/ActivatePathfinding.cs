using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ActivatePathfinding : MonoBehaviour
{
    private AstarPath path;
    bool worldIsNotGenerated = true;

    private void Start()
    {
        path = this.GetComponent<AstarPath>();
    }

    void Update()
    {
        if (worldIsNotGenerated)
        {
            StartCoroutine(Timer());
            worldIsNotGenerated = false;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5F);
        path.Scan(); /// Scans the level to generate the pathfinding navigation grid
    }
}
