using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeepOnLoad : MonoBehaviour {

    public string levelToLoad = "houseHome";

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("SetupScene"))
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
