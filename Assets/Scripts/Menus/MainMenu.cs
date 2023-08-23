using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [Header("Menu Buttons")]
    [SerializeField] private Button loadGameButton;

    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    private void Start()
    {

        if (!DataPersistenceManager.instance.HasGameData()) //Checks whether there is any previously saved games
        {
            loadGameButton.interactable = false; //If there are not, then the load game button is not interactable
        }
    }

    public void NewGame()
    {
        saveSlotsMenu.ActivateMenu(true);
        DataPersistenceManager.instance.newGame = true; //The user wants to load a new game
    }
    
    public void LoadGame()
    {
        saveSlotsMenu.ActivateMenu(false);
        DataPersistenceManager.instance.newGame = false; //The user wants to load previously saved game
    }
    
    public void QuitGame()
    {
        Debug.Log("Game has been QUIT.");
        Application.Quit(); //Quits the application
    }
}
