using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class KeepOnLoad : MonoBehaviour {

    public static KeepOnLoad masterObject;

    public string levelToLoad = "houseHome";
    private string filePath = Application.persistentDataPath + "/PlayerData.dat";

    public int exp = 0;
    public int completedLevel = 0;
    public ArrayList items = new ArrayList();

    void Awake()
    {
        if(masterObject == null)
        {
            DontDestroyOnLoad(gameObject);
            masterObject = this;
        } 
        else if(masterObject != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter binform = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        PlayerData playerData = new PlayerData();
        if(playerData.PlayerExp <= 0) { playerData.PlayerExp = 0; }
        else { playerData.PlayerExp = exp; }

        if(playerData.CompletedLevel <= 0) { playerData.CompletedLevel = 0; }
        else { playerData.CompletedLevel = this.completedLevel; }

        playerData.items = this.items;

        binform.Serialize(file, playerData);
        file.Close();
        print("Game successfully saved!");
    }

    public void Load()
    {
        if (!File.Exists(filePath){ print("Game file not found " + filePath); return; }
        BinaryFormatter binform = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);
        PlayerData playerData = (PlayerData) binform.Deserialize(file);
        file.Close();

        exp = playerData.PlayerExp;
        completedLevel = playerData.CompletedLevel;
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
