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
        if(spawnPoint.levelGenerated && worldIsNotGenerated)
        {
            path.Scan(); /// Scans the level to generate the pathfinding navigation grid
            worldIsNotGenerated = false;
        }
    }
}
