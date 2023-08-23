using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileID = ""; //Name within Unity Inspector i.e. SaveSlot1
    [Header("Content")]
    [SerializeField] private Button thisButton;
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;

    private void Awake()
    {
        thisButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        //Shows either 'Progress' or 'Empty' based on whether a save slot has saved game data
        if (data.hasSavedData == false)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
        }

    }

    public string GetProfileID()
    {
        return this.profileID;
    }

    public void SetInteractable(bool interactable)
    {
        //Enables/Disables button based on input
        if (interactable)
        {
            thisButton.interactable = true;
        }
        else
        {
            thisButton.interactable = false;
        }
    }

}
