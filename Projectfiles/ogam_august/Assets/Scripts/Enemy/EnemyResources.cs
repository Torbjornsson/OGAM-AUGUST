using UnityEngine;
using System.Collections;

public class EnemyResources : EntityResources {

    [SerializeField]
    private int BaseExp = 1;


    [SerializeField]
    private int EnemyMaxHealth = 5;

	void Start ()
    {
        MaxHealth = EnemyMaxHealth;
        Health = EnemyMaxHealth;
	}

    public override void DeathCheck()
    {
        if(Health <= 0)
        {
            SpawnLoot();
            GiveExp();
            Destroy(gameObject);
        }
    }

    void SpawnLoot()
    {
        print("Future spawn loot @ " + transform.position);
    }

    void GiveExp()
    {
        MasterObjectControl.masterObject.mocExperience += BaseExp;
    }
}
