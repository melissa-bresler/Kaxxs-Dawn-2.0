using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileID = "";
    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;


    public void SetData(GameData data)
    {
        if (data.hasSavedData == false)
        {
            Debug.Log("There is NO saved data.");
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            Debug.Log("There is saved data.");
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
        }

    }


    public string GetProfileID()
    {
        return this.profileID;
    }


}
