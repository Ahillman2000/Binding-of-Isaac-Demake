using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ActivatePathfinding : MonoBehaviour
{
    bool worldIsNotGenerated = true;

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
        AstarData.active.Scan(); /// Scans the level to configure the pathfinding navigation grid
    }
}
