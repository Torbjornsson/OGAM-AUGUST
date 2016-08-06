using UnityEngine;
using System.Collections;

public class EntityResources : MonoBehaviour {

    [SerializeField]
    protected int Health = 1;
    [SerializeField]
    protected int MaxHealth = 1;

    public virtual void HealthRemove(int i)
    {
        if(i >= 0)
        {
            Health -= i;
            ControlHealthValues();
            DeathCheck();
        }
    }

    public virtual void HealthIncrease(int i)
    {
        if(i >= 0)
        {
            Health += i;
            ControlHealthValues();
        }
    }

    private void ControlHealthValues()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
    }

    public virtual void DeathCheck()
    {
        if(Health <= 0)
        {
            Debug.Log(gameObject.name + " is dead, do something?");
        }
    }

    public int GetHealth()
    {
        return Health;
    }
}
