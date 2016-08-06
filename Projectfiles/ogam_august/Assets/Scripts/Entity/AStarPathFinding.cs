using UnityEngine;
using System.Collections;

public class AStarPathFinding : MonoBehaviour {

    [SerializeField]
    private string searchForTag = "Player";

    private float LerpSpeed = 20;
    
    private Transform tagTransform;
    
    private GameObject tmpGO;
    private GameObject MasterObject;
    private EnemyInformation eInfo;

    Vector3[] closestTiles = new Vector3[4];
    Vector3 closestPath;
    Vector3 moveToPos;

    Collider[] cols;

    void Start()
    {
        moveToPos = transform.position;
    }

	void Update ()
    {
        if (!tagTransform)
        { 
            tmpGO = GameObject.FindGameObjectWithTag(searchForTag);
            if (tmpGO) { tagTransform = tmpGO.transform; }
        }
        if (!MasterObject)
        {
            MasterObject = GameObject.Find("MasterObject");
        } 
        else if(!eInfo)
        {
            eInfo = MasterObject.GetComponentInChildren<EnemyInformation>();
        }
	}

    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, moveToPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, moveToPos, LerpSpeed * Time.deltaTime);
        }
        else
        {
            if (moveToPos != transform.position)
            {
                transform.position = moveToPos;
            }
        }
    }

    public void PerformMove()
    {
        moveToPos = GetClosestAvailablePath();   
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
                if(closestPath == tagTransform.position) { closestPath = transform.position; }
                else
                {
                    closestPath = closestTiles[i];
                }
            }
        }

        if (eInfo)
        {
            print("========> " + gameObject.name + " <=====");

            eInfo.OccupiedSpaces.Remove(transform.position);
            eInfo.OccupiedSpaces.Add(closestPath);

            foreach(Vector3 v in eInfo.OccupiedSpaces)
            {
                print(v);
            }
            print("removed: " + transform.position + " added: " + closestPath);
        }
        return closestPath;
    }

    bool CheckClosestTiles(Vector3 checkPos)
    {
        if (eInfo)
        {
            if (eInfo.OccupiedSpaces.Contains(checkPos))
            {
                return true;
            }
        }
        cols = Physics.OverlapBox(checkPos, new Vector3(0.25f, 0.25f, 0.2f));
        return cols.Length > 0;
    }
}
