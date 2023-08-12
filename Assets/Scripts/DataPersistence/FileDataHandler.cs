using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";


    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }


    public GameData Load(string profileID)
    {
        string fullPath = Path.Combine(dataDirPath, profileID, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }


                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                Debug.Log("File found and data loaded. \n FileDataHandler Script."); //This appears on the console.
                //Debug.Log(Application.persistentDataPath);
                //Debug.Log(fullPath);
            }
            catch (Exception e)
            {
                Debug.LogError("ERROR occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data, string profileID)
    {
        string fullPath = Path.Combine(dataDirPath, profileID, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

            Debug.Log("Data saved to file.");
            //Debug.Log(Application.persistentDataPath);
           // Debug.Log(fullPath);

        }
        catch (Exception e)
        {
            Debug.LogError("ERROR occured when trying to save data to file: " + fullPath + "\n" + e);

        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();

        foreach (DirectoryInfo dirInfo in dirInfos)
        {
            string profileID = dirInfo.Name;
            Debug.Log("Directory Info Name: " + dirInfo.Name);
            string fullPath = Path.Combine(dataDirPath, profileID, dataFileName);
            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: " + profileID);
                continue;
            }

            GameData profileData = Load(profileID);
            profileData.SetHasSavedData();

            Debug.Log("Player position: " + profileData.playerPosition);
            Debug.Log("Player health: " + profileData.health);
            Debug.Log("Max health: " + profileData.maxHealth);

            if (profileData != null)
            {
                profileDictionary.Add(profileID, profileData);
            }
            else
            {
                Debug.LogError("Tried to load profile but something went wrong. Profile ID: " + profileID);
            }
        }

        return profileDictionary;
    }



}
