using UnityEngine;
using System.Collections;

public class EnemyInformation : MonoBehaviour {

    private GameObject[] allEnemies;
    private AStarPathFinding aspf;
    private int counter = 0;
    [SerializeField]
    private bool allEnemiesDone = true;

    void Update()
    {
        if (aspf && !allEnemiesDone)
        {
            print("its " + aspf.gameObject.name + "'s turn");
            if (aspf.finishedMove())
            {
                Invoke("IncreaseASPF", 0.2f);
            }
        }   
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
}
