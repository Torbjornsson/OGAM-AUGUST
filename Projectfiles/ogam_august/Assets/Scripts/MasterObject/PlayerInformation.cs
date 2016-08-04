using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {

    private int Exp = 0;
    private int Lvl = 1;
    private float ExpReqScaler = 1000;

    public int GetExp()
    {
        return Exp;
    }

    public int GetLvl()
    {
        return Lvl;
    }

    public void IncreaseExp(int i)
    {
        if (i < 0) { return; }
        
        Exp += i;
        Debug.Log("Increasing exp by " + i + " current exp: " + Exp + " / " + (Lvl * ExpReqScaler));

        CheckIfLvl();
    }

    public void CheckIfLvl()
    {
        if(Exp >= (Lvl * ExpReqScaler))
        {
            Exp -= (int) (Lvl * ExpReqScaler);
            Debug.Log("new exp: " + Exp);
            Lvl++;
            Debug.Log("Ding! Reached lvl: " + Lvl);
        }
    }
}
