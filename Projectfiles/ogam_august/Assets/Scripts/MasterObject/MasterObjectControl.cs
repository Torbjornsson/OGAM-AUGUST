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

	void Awake()
    {
        filePath = Application.persistentDataPath + "/PlayerData.dat";
        if (masterObject == null)
        {
            DontDestroyOnLoad(gameObject);
            masterObject = this;
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

        if (playerData.CompletedLevel <= 0) { playerData.CompletedLevel = 0; }
        else { playerData.CompletedLevel = mocCompletedLevel; }

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
        PlayerData playerData = (PlayerData)binform.Deserialize(file);
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
