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

        if (!DataPersistenceManager.instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
    }

    public void NewGame()
    {
        saveSlotsMenu.ActivateMenu(true);
        DataPersistenceManager.instance.newGame = true;
    }
    
    public void LoadGame()
    {
        saveSlotsMenu.ActivateMenu(false);
        DataPersistenceManager.instance.newGame = false;
    }
    
    
    public void QuitGame()
    {
        Debug.Log("Game has been QUIT.");
        Application.Quit();
    }
}
