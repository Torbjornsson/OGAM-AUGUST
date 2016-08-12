using UnityEngine;
using System.Collections;

public class MeleeAI : AI {

    AStarPathFinding pathfinding;

    private GameObject playerToHit;

    private int damage = 2;

    void Start()
    {
        playerToHit = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!pathfinding)
        {
            pathfinding = gameObject.GetComponent<AStarPathFinding>();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformAction();
        }
    }

    public override void PerformAction()
    {
        if (IsPlayerClose())
        {
            playerToHit.GetComponent<EntityResources>().HealthRemove(damage);       
        }
        else
        {
            pathfinding.PerformMove();
        }
    }

    private bool IsPlayerClose()
    {
        if (playerToHit)
        {
            if(playerToHit.transform.position == (transform.position + Vector3.up) ||
                playerToHit.transform.position == (transform.position + Vector3.right) ||
                playerToHit.transform.position == (transform.position + Vector3.down) ||
                playerToHit.transform.position == (transform.position + Vector3.left) )
            {
                return true;
            }
        }

        return false;
    }

}
