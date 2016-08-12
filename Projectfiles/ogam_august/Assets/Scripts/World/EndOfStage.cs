using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndOfStage : MonoBehaviour {

    [SerializeField]
    private string NextLevel = "main";

	void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag.Equals("Player"))
        {
            Debug.Log("Leave stage, loading " + NextLevel);
            MasterObjectControl.masterObject.Save();
            SceneManager.LoadScene(NextLevel);
        }
    }
}
