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
        dataPersistanceManager = GetComponent<DataPersistenceManager>();
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        //Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }

    public void SaveGame()
    {
        Debug.Log("Saving game from pause menu script.");
        DataPersistenceManager.instance.SaveGame();
    }
}
