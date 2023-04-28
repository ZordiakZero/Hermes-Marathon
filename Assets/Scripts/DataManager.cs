using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerDataSaveObject
{
    public int MaxLevelUnlocked;
}
public class DataManager
{
    public static string saveDirectory = "/SaveData/";
    public static string playerDataFileName = "PlayerData";

    public static void SavePlayerData(PlayerDataSaveObject saveObject)
    {
        string dir = Application.persistentDataPath + saveDirectory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string jsonSaveObject = JsonUtility.ToJson(saveObject);
        File.WriteAllText(dir + playerDataFileName, jsonSaveObject);
    }

    public static PlayerDataSaveObject LoadPlayerData()
    {
        string playerDataPath = Application.persistentDataPath + saveDirectory + playerDataFileName;
        PlayerDataSaveObject saveObject = new PlayerDataSaveObject();

        if (File.Exists(playerDataPath))
        {
            string fileContentsJson = File.ReadAllText(playerDataPath);
            saveObject = JsonUtility.FromJson<PlayerDataSaveObject>(fileContentsJson);
        }

        return saveObject;
    }
}
