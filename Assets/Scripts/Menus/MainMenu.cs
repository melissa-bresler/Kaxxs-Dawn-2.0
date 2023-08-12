using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [Header("Menu Buttons")]
    [SerializeField] private Button loadGameButton;

    private void Start()
    {

        if (!DataPersistenceManager.instance.HasGameData())
        {
            //loadGameButton.interactable = false;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("Loading next scene.");
    }
    
    public void NewGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //ChangeScene();
    }
    /*
    public void LoadGame()
    {
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */
    
    public void QuitGame()
    {
        Debug.Log("Game has been QUIT.");
        Application.Quit();
    }
}
