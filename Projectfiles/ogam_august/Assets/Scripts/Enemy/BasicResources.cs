using UnityEngine;
using System.Collections;

public class BasicResources : EntityResources {

    [SerializeField]
    private int MaxHealth = 5;

    void Start()
    {
        Health = MaxHealth;
    }

    public override void DeathCheck()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
