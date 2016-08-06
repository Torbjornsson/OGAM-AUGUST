using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    AStarPathFinding pathfinding;

    void Update()
    {
        if (!pathfinding)
        {
            pathfinding = gameObject.GetComponent<AStarPathFinding>();
        }
    }

    public void PerformAction()
    {
        pathfinding.PerformMove();
    }

}
