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
                //Debug.Log("File found and data loaded. \n FileDataHandler Script.");

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

            //Debug.Log("Data saved to file.");
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
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>(); //Empty Dictionary

        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories(); //Finds all folders within assigned path

        foreach (DirectoryInfo dirInfo in dirInfos) //For each folder
        {
            string profileID = dirInfo.Name; //Makes the ID the name of the folder i.e. SaveSlot1
            Debug.Log("Directory Info Name: " + dirInfo.Name);

            string fullPath = Path.Combine(dataDirPath, profileID, dataFileName); //if folder is empty i.e. has no data

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: " + profileID);
                continue;
            }

            GameData profileData = Load(profileID); //Game data copies info from file for each slot/file?
            profileData.SetHasSavedData(); //Game data now chaged t has saved data, but only in game, not on computer

            //Debug.Log("Player position: " + profileData.playerPosition);
            //Debug.Log("Player health: " + profileData.health);
            //Debug.Log("Max health: " + profileData.maxHealth);

            if (profileData != null)
            {
                profileDictionary.Add(profileID, profileData);
            }
            else
            {
                Debug.LogError("Tried to load profile but something went wrong. Profile ID: " + profileID);
            }
        }

        return profileDictionary; //Return dictionary of game data with corresponding IDs as key. TODO: What is the ID? Linked to Name.
    }

    public bool FindIfSavedData()
    {
        int count = 0;
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories(); //Finds all folders within assigned path

        foreach (DirectoryInfo dirInfo in dirInfos)
        {
            count++;
        }

        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
