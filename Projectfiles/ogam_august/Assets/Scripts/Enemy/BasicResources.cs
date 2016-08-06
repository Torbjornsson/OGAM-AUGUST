using UnityEngine;
using System.Collections;

public class BasicResources : EntityResources {
    
    private EnemyInformation ei;
    [SerializeField]
    private int basicMaxHealth = 6;

    void Start()
    {
        Health = basicMaxHealth;
    }

    void Update()
    {
        if (!ei)
        {
            GameObject go = GameObject.Find("MasterObject");
            if (go)
            {
                print(go.name);
                ei = go.GetComponentInChildren<EnemyInformation>();
                if (!ei) { print("Why not found "); }
            }
        }
    }

    public override void HealthRemove(int i)
    {
        base.HealthRemove(i);
    }

    public override void DeathCheck()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
