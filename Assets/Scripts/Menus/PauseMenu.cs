using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private DataPersistenceManager dataPersistanceManager;

    private void Awake()
    {
        dataPersistanceManager = GetComponent<DataPersistenceManager>(); //Finds corresponding object
    }

    private void OnPause()
    {

        if (GameIsPaused)
        {
            Resume();
        }
        else if (!GameIsPaused)
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false); //Disables the object
        Time.timeScale = 1f; //Resumes time
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //Enables the object
        Time.timeScale = 0f; //Stops time
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        StartCoroutine(PauseAndContinue()); //Invokes co-routine
        Time.timeScale = 1f; //Resumes time
        SceneManager.LoadScene("MainMenu"); //Changes scene to MainMenu scene
    }

    public void QuitGame()
    {
        StartCoroutine(PauseAndContinue()); //Invokes co-routine
        Debug.Log("Quiting Game...");
        Application.Quit(); //Quits the application
    }

    public void SaveGame()
    {
        DataPersistenceManager.instance.SaveGame(); //Invokes the SaveGame method from the DataPersistanceManager script
    }

    IEnumerator PauseAndContinue()
    {
        SaveGame();
        yield return new WaitForSeconds(3f); //Waits 3 seconds after SaveGame has been invokes before moving on to other code
    }

}
