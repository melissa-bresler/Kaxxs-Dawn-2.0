using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")] //Adds a header into the Inspector in Unity
    [SerializeField] private string fileName; //data.game //Written into Unity Inspector

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    private string selectedProfileID = "";
    public static DataPersistenceManager instance { get; private set; }
    public bool newGame = true;
    public SavingUI savingUI;

    private void Awake() //Ensures only one DataPersistanceManager is in the scene
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);

            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        if (scene.name != "MainMenu") //i.e. the user has entered the game
        {
            //loads/starts game based on which button the user pressed before selecting a save slot
            if (newGame == false)
            {
                LoadGame();
            }
            else
            {
                NewGame();
            }

        }
        
    }

    public void ChangeSelectedProfileID(string newProfileID)
    {
        this.selectedProfileID = newProfileID;
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() //Finds all objects with attached script implementing IDataPersistence
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        Debug.Log("Populating dataPersistanceObjects list.");

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void NewGame() //Sets all data back to the constructor default values in GameData
    {
        this.gameData = new GameData();

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) //Ensures new data is loaded into game
        {
            dataPersistenceObj.LoadData(gameData); //Grabs data from file and copies it onto each appropriate script.
        }

    }

    public void LoadGame()
    {

        this.gameData = dataHandler.Load(selectedProfileID); //Loads data from selected SaveSlot

        if (this.gameData == null) //Failsafe. Shouldn't be needed if buttons are not interacatable as intended.
        {
            Debug.Log("No data was found. A new game needs to be started before data can be loaded.");
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData); //Grabs data from file and copies it onto each appropriate script.
        }
    }

    public void SaveGame()
    {
        this.gameData = new GameData(); //Creates a blank slate for saving the data

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);//Grabs data from each specified script and copies it onto file.
        }

        dataHandler.Save(gameData, selectedProfileID); //Saves collected data with corresponding profile ID
        savingUI.SaveText(); //Displays visual for user to see that the game is saving

    }

    public bool HasGameData()
    {
        return dataHandler.FindIfSavedData();
    }

    public Dictionary<string, GameData> GetAllProfilesGameData() //Retrieves all game data
    {
        return dataHandler.LoadAllProfiles();
    }

}
