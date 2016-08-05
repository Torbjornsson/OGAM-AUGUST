using UnityEngine;
using System.Collections;

public class PlayerResources : EntityResources {

    [SerializeField]
    private int MaxHealth = 20;

	void Start()
    {
        Health = MaxHealth;
    }

    public override void DeathCheck()
    {
        if(Health <= 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
