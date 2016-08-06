using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeepOnLoad : MonoBehaviour {

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("SetupScene"))
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
