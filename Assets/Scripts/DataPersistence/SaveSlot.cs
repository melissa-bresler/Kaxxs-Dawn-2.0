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
        if (data.hasSavedData == false)
        {
            
            //thisButton.interactable = false; //Should disable button if there is no saved data attached to it
            //Debug.Log("There is NO saved data.");
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            //Debug.Log("There is saved data.");
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
