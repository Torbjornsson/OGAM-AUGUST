using UnityEngine;
using System.Collections;

public class EnemyInformation : MonoBehaviour {

    GameObject[] allEnemies;
    public ArrayList OccupiedSpaces = new ArrayList();

    void OnLevelWasLoaded(int i)
    {
        OccupiedSpaces.Clear();
    }

    public void MakeEnemiesPerformActions()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in allEnemies)
        {
            AI ai = g.GetComponent<AI>();
            if (ai)
            {
                ai.PerformAction();
            }
        }
    }
}
