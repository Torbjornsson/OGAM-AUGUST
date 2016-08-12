using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MasterObjectControl : MonoBehaviour {

    public static MasterObjectControl masterObject;

    public string SceneToLoad = "main";
    private string filePath;

    public int mocExperience = 0;
    public int mocCompletedLevel = 0;
    public ArrayList mocItems = new ArrayList();

    public string canvasPath = "Prefabs/UICanvasBase";
    public string eventPath = "Prefabs/Eventsystem";

	void Awake()
    {
        filePath = Application.persistentDataPath + "/PlayerData.dat";
        if (masterObject == null)
        {
            DontDestroyOnLoad(gameObject);
            masterObject = this;
            GameObject tmpgo = Resources.Load<GameObject>(canvasPath);
            Instantiate(tmpgo);
            GameObject eventsys = Resources.Load<GameObject>(eventPath);
            Instantiate(eventsys);
            Load();
        }
        else if (masterObject != this)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("SetupScene"))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void Save()
    {
        BinaryFormatter binform = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        PlayerData playerData = new PlayerData();
        if (playerData.PlayerExp <= 0) { playerData.PlayerExp = 0; }
        else { playerData.PlayerExp = mocExperience; }

        playerData.PlayerExp = mocExperience;
        playerData.CompletedLevel = mocCompletedLevel;
        playerData.items = mocItems;

        binform.Serialize(file, playerData);
        file.Close();
        print("Game successfully saved!");
    }

    public void Load()
    {
        if (!File.Exists(filePath)) { print("Game file not found " + filePath); return; }
        BinaryFormatter binform = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);
        PlayerData playerData = (PlayerData) binform.Deserialize(file);
        file.Close();

        mocExperience = playerData.PlayerExp;
        mocCompletedLevel = playerData.CompletedLevel;
        mocItems = playerData.items;
        print("Game successfully loaded!");
    }
}

[Serializable]
class PlayerData
{
    public int PlayerExp;
    public int CompletedLevel;
    public ArrayList items;
}
