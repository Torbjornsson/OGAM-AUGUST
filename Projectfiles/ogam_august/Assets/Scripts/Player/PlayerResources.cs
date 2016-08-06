using UnityEngine;
using System.Collections;

public class PlayerResources : EntityResources {

    private int playerMaxHealth = 20;

	void Start()
    {
        MaxHealth = playerMaxHealth;
        Health = playerMaxHealth;
    }

    public override void DeathCheck()
    {
        if(Health <= 0)
        {
            Debug.Log("Player is dead");
        }
    }

    public int GetMaxHealth()
    {
        return MaxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) { HealthRemove(10); }
        if (Input.GetKeyDown(KeyCode.J)) { HealthIncrease(5); }
    }
}
