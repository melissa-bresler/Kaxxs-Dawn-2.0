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

        if (File.Exists(fullPath)) //Checks if the file exists
        {
            try //Loads the data from the file
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

        try //Saves inputed data to the specified file
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)); //If the file does not exist it creates one, otherwise it overwrites the current data with the new data

            string dataToStore = JsonUtility.ToJson(data, true);

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

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

            string fullPath = Path.Combine(dataDirPath, profileID, dataFileName); //If folder is empty i.e. has no data

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: " + profileID);
                continue;
            }

            GameData profileData = Load(profileID); //Copies game data from file to each corresponding slot
            profileData.SetHasSavedData(); //Game data now changed to has saved data, but only in game, not on computer

            if (profileData != null)
            {
                profileDictionary.Add(profileID, profileData); //Adds profile ID and data to dictionary
            }
            else
            {
                Debug.LogError("Tried to load profile but something went wrong. Profile ID: " + profileID);
            }
        }

        return profileDictionary; //Returns dictionary of game data with corresponding IDs as key.
    }

    public bool FindIfSavedData()
    {
        int count = 0;
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories(); //Finds all folders within assigned path

        foreach (DirectoryInfo dirInfo in dirInfos) //Counts the number of directories found
        {
            count++;
        }

        if (count > 0) //If directories found
        {
            return true;
        }
        else //If no directories found
        {
            return false;
        }
    }



}
