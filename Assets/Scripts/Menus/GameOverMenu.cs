using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); //Changes game scene back to main menu
        Time.timeScale = 1f; //Starts time in the application once again
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit(); //Quits the application
    }
}
