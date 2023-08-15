using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSlotsMenu : MonoBehaviour
{
    private SaveSlot[] saveSlots;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
        //ActivateMenu();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DataPersistenceManager.instance.ChangeSelectedProfileID(saveSlot.GetProfileID()); //This must go before LoadGame. Need to know what to load before loading it.
        //DataPersistenceManager.instance.NewGame();
        DataPersistenceManager.instance.newGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void ActivateMenu()
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData(); //Creates dictionary of Save Slots with retrieved data

        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null; //Each save slot has a game data variable called profileData

            Debug.Log("Save Slot ID: " + saveSlot.GetProfileID()); //i.e. ID: SaveSlot1

            //if (profilesGameData.ContainsKey(saveSlot.GetProfileID())) //Save slot name must match game data key i.e. ID
            //{
                profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData); //Retrieves information from matching ID
                saveSlot.SetData(profileData); //Alters button according to what information the data contains
            //}
            /*else
            {
                Debug.Log("Nothing to be loaded.");
            }*/
            if(profileData == null)
            {
                saveSlot.SetInteractable(false);
            }
            
        }
    }
}
