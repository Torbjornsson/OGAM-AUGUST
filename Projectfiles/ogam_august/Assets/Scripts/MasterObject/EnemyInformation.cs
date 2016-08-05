using UnityEngine;
using System.Collections;

public class EnemyInformation : MonoBehaviour {

    private GameObject[] allEnemies = new GameObject[0];
    private AStarPathFinding aspf;
    private int counter = 0;
    [SerializeField]
    private bool allEnemiesDone = true;

    void Update()
    {
        if (aspf && !allEnemiesDone)
        {  
            if (aspf.finishedMove())
            {
                Invoke("IncreaseASPF", 0.2f);
            }
        }

        if (allEnemies.Length == 0) { allEnemiesDone = true; } 
    }

    public void MakeMove()
    {
        allEnemiesDone = false;
        counter = 0;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        IncreaseASPF();
    }

    private void IncreaseASPF()
    {
        if(counter == allEnemies.Length)
        {
            allEnemiesDone = true;
        } else if (allEnemies.Length > 0)
        {
            GameObject go = allEnemies[counter];
            if (go)
            {
                aspf = go.GetComponent<AStarPathFinding>();
                aspf.PerformMove();
            }
            counter++;
        } else if(!allEnemiesDone)
        {
            allEnemiesDone = true;
        }
    }

    public bool areEnemiesDone()
    {
        return allEnemiesDone;
    }

    public void invokeEnemyUpdate()
    {
        Invoke("ForceEnemyUpdate", 0.3f);
    }

    public void ForceEnemyUpdate()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
