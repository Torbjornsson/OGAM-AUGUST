using UnityEngine;
using System.Collections;

public class EndOfStage : MonoBehaviour {

	void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.tag + " entered");
        if (c.tag.Equals("Player"))
        {
            Debug.Log("Load next scene");
        }
    }

}
