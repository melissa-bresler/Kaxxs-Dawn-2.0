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
        ActivateMenu();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DataPersistenceManager.instance.ChangeSelectedProfileID(saveSlot.GetProfileID());
        //DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ActivateMenu()
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;

            Debug.Log("ID: " + saveSlot.GetProfileID());

            if (profilesGameData.ContainsKey(saveSlot.GetProfileID()))
            {
                profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData);
                saveSlot.SetData(profileData);
            }
            else
            {
                Debug.Log("Nothing to be loaded.");
            }
            
        }
    }
}
