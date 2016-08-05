using UnityEngine;
using System.Collections;

public class EntityResources : MonoBehaviour {

    [SerializeField]
    protected int Health = 1;

    public virtual void HealthRemove(int i)
    {
        if(i >= 0)
        {
            Health -= i;
            DeathCheck();
        }
    }

    public virtual void DeathCheck()
    {
        if(Health <= 0)
        {
            Debug.Log(gameObject.name + " is dead, do something?");
        }
    }
}
