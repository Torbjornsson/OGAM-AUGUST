using UnityEngine;
using System.Collections;

public class AStarPathFinding : MonoBehaviour {

    [SerializeField]
    private string searchForTag = "Player";
    private Transform tagTransform;
    private GameObject tmpGO;

    Vector3[] closestTiles = new Vector3[4];
    Vector3 closestPath;
    
    Vector3 currentPos;
    Vector3 endPos;

    Collider[] cols;

	void Update ()
    {
        if (!tagTransform)
        { 
            tmpGO = GameObject.FindGameObjectWithTag(searchForTag);
            if (tmpGO) { tagTransform = tmpGO.transform; }
        }
	}

    public void PerformMove()
    {
        transform.position = GetClosestAvailablePath();
    }

    Vector3 GetClosestAvailablePath()
    {
        if(!tagTransform) { Debug.Log("Missing transform for path, returning vector3.zero"); return Vector3.zero; }

        closestTiles = new Vector3[4] { transform.position, transform.position, transform.position, transform.position };
        if (!CheckClosestTiles(transform.position + Vector3.up)) { closestTiles[0] = transform.position + Vector3.up; }
        if(!CheckClosestTiles(transform.position + Vector3.right)) { closestTiles[1] = transform.position + Vector3.right; }
        if(!CheckClosestTiles(transform.position + Vector3.down)) { closestTiles[2] = transform.position + Vector3.down; }
        if(!CheckClosestTiles(transform.position + Vector3.left)) { closestTiles[3] = transform.position + Vector3.left; }

        closestPath = transform.position;
        for(int i = 0; i < 4; i++)
        {
            if (closestTiles[i] != transform.position && 
                Vector3.Distance(closestTiles[i], tagTransform.position) <= Vector3.Distance(closestPath, tagTransform.position))
            {
                closestPath = closestTiles[i];
            }
        }
        return closestPath;
    }

    bool CheckClosestTiles(Vector3 checkPos)
    {
        cols = Physics.OverlapBox(checkPos, new Vector3(0.25f, 0.25f, 0.2f));
        return cols.Length > 0;
    }
}
