using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int Damage = 1;
    private int zRot = 0;

    private player_movement PM;

    private Quaternion q = Quaternion.identity;

    private string AttackInput = "Jump";

    private Vector3 direction = Vector3.zero;

    void Start()
    {
        if (!PM) { PM = GetComponent<player_movement>(); }
    }
    
    void OnEnable()
    {
        if (!PM) { PM = GetComponent<player_movement>(); }
    }

    void Update()
    {
        if (Input.GetButtonDown(AttackInput))
        {
            AttackFront();
        }
    }

	public virtual void WeaponAttack(GameObject g)
    {
        EntityResources ER = g.GetComponent<EntityResources>();
        if (ER) { ER.HealthRemove(Damage); }
    }

    protected void AttackFront()
    {
        q = PM.GetEntityRotation();
        zRot = (int) q.eulerAngles.z;
        direction = Vector3.zero;
        switch (zRot)
        {
            case 0: direction.y = 1; break;
            case 90: direction.x = -1; break;
            case 180: direction.y = -1; break;
            case 270: direction.x = 1; break;
            default: break;
        }

        Collider[] c = Physics.OverlapBox(transform.position + direction, new Vector3(0.25f, 0.25f, 0.2f));
        foreach(Collider k in c)
        {
            Debug.Log(k.gameObject.name + " hit ");
            WeaponAttack(k.transform.root.gameObject);
        }
    }
}
