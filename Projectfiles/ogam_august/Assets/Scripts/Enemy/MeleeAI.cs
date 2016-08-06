using UnityEngine;
using System.Collections;

public class MeleeAI : AI {

    AStarPathFinding pathfinding;

    void Start()
    {
        print("melee ai start");
    }

    void Update()
    {
        if (!pathfinding)
        {
            pathfinding = gameObject.GetComponent<AStarPathFinding>();
        }
    }

    public override void PerformAction()
    {
        print("melee ai stuff");
        pathfinding.PerformMove();
    }

}
