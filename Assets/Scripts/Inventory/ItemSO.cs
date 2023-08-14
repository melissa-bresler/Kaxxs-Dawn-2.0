using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public GameObject itemPrefab;



    public bool UseItem()
    {
        if(statToChange == StatToChange.health)
        {
            PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            if(playerHealth.health == playerHealth.maxHealth)
            {
                Debug.Log("Player already has full health. Cannot use item.");
                return false;
            }
            else
            {
                playerHealth.HealHealth(amountToChangeStat);
                return true;
            }

            //Debug.Log("SO is trying to use the item and increase the Player's health.");
        }
        return false;
    }



    public enum StatToChange
    {
        none, health
    };




}
