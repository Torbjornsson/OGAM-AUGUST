using UnityEngine;
using System.Collections;

public class EnemyInformation : MonoBehaviour {

    private GameObject[] allEnemies;
    private AStarPathFinding aspf;

    public void MakeMove()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject go in allEnemies)
        {
            if (go.activeSelf)
            {
                aspf = go.GetComponent<AStarPathFinding>();
                if (aspf) { aspf.PerformMove(); }
            }
        }
    }
}
