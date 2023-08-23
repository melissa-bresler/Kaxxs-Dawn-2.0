using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSlotsMenu : MonoBehaviour
{
    private SaveSlot[] saveSlots;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>(); //Collects children of object and stores them in array
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DataPersistenceManager.instance.ChangeSelectedProfileID(saveSlot.GetProfileID()); //Finds corresponding ID for the save slot and changes the current ID to this
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Changes scene to next in queue i.e. Game
        
    }

    public void ActivateMenu(bool newGame)
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData(); //Creates dictionary of Save Slots with retrieved data

        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null; //Each save slot has a game data variable called profileData

            if (profilesGameData.ContainsKey(saveSlot.GetProfileID())) //Save slot name must match game data key i.e. ID
            {
                profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData); //Retrieves information from matching ID
                saveSlot.SetData(profileData); //Alters button according to what information the data contains
            }
            else
            {
                Debug.Log("Nothing to be loaded to " + saveSlot.GetProfileID());
            }
            if(profileData == null) //If there is no data for that save slot
            {
                if (!newGame) //If the user is not starting a new game
                {
                    saveSlot.SetInteractable(false); //Disables button
                }
                else
                {
                    saveSlot.SetInteractable(true); //Enables button
                }
                
            }
            
        }
    }
}
