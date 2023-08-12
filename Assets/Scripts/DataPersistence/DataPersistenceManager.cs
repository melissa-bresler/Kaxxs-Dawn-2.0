using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")] //Adds a header into the Inspector in Unity
    [SerializeField] private string fileName;


    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string selectedProfileID = "test";

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);

            //this.selectedProfileID = "test";
            //LoadGame();

            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += onSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= onSceneUnloaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded called");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame(); //Loads game on startup of scene.
    }


    public void onSceneUnloaded(Scene scene)
    {
        //Debug.Log("OnSceneUnloaded called.");
        //SaveGame();
    }
    /*
    private void Start()
    {
        
    }*/

    public void ChangeSelectedProfileID(string newProfileID)
    {
        this.selectedProfileID = newProfileID;
        //Invoke("LoadGame", 1f);
        //StartCoroutine(LoadGame());
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        Debug.Log("Populating dataPersistanceObjects list."); //This prints to the console.
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void NewGame()
    {
        Debug.Log("Creating New Game!");
        this.gameData = new GameData();
    }

    //IEnumerator LoadGame()
    public void LoadGame()
    {

        this.gameData = dataHandler.Load(selectedProfileID); //This works
        //gameData.SetHasSavedData();

        Debug.Log("Player position: " + this.gameData.playerPosition);
        Debug.Log("Player health: " + this.gameData.health);
        Debug.Log("Max health: " + this.gameData.maxHealth);

        if (this.gameData == null)
        {
            Debug.Log("No data was found. A new game needs to be started before data can be loaded.");
            //NewGame();
        }
        /*
        while(dataPersistenceObjects.Count() == 0) //This pauses the method until the value is true and then continues where it left off.
        {
            Debug.Log("Co-routine running.");
            yield return new WaitForSeconds(1f);
        }
        */
        Debug.Log("Data Persistance Objects: " + dataPersistenceObjects.Count());

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            Debug.Log("Loading data...");
            dataPersistenceObj.LoadData(gameData); //Grabs data from file and copies it onto each appropriate script.
        }

        //Debug.Log("Loaded health: " + gameData.health);
        //Debug.Log("Loaded maxHealth: " + gameData.maxHealth);
        Debug.Log("Loaded playerPosition: " + gameData.playerPosition); //This appears on the console.
    }

    public void SaveGame()
    {
        this.gameData = new GameData();
        Debug.Log("Game data: " + this.gameData);

        if(this.gameData == null)
        {
            Debug.LogWarning("Game data is null. A new game needs to be started before data can be saved.");
            //this.gameData = new GameData();
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) //This line causing issues
        {
            Debug.Log("Saving data..."); //This appears on the console.
            dataPersistenceObj.SaveData(gameData); //ref
        }

        //Debug.Log("Saved health: " + gameData.health);
        //Debug.Log("Saved maxHealth: " + gameData.maxHealth);
        //Debug.Log("Saved playerPosition: " + gameData.playerPosition); //This appears on the console.


        dataHandler.Save(gameData, selectedProfileID);

    }
    /*
    //Delete later. Saves game when quitting the application.
    //private void OnApplicationQuit()
    public void Save()
    {
        Debug.Log("SAVING GAME...");
        if (gameData == null) //Delete later
        {
            Debug.LogError("Game data is null in Save() method."); //Null here
        }
        SaveGame();
    }
    */

    public bool HasGameData()
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
