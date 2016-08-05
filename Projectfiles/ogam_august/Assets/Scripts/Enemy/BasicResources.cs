using UnityEngine;
using System.Collections;

public class BasicResources : EntityResources {

    [SerializeField]
    private int MaxHealth = 5;
    private EnemyInformation ei;

    void Start()
    {
        Health = MaxHealth;
    }

    void Update()
    {
        if (!ei)
        {
            GameObject go = GameObject.Find("MasterObject");
            if (go)
            {
                ei = go.GetComponentInChildren<EnemyInformation>();
            }
        }
    }

    public override void HealthRemove(int i)
    {
        if (ei) { ei.ForceEnemyUpdate(); }
        base.HealthRemove(i);
    }

    public override void DeathCheck()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (ei) { ei.invokeEnemyUpdate(); } else { print("missing ei"); }
    }
}
