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
        if(statToChange == StatToChange.health) //If the item has health as it's affected stat
        {
            PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>(); //Finds PlayerHealth script

            if(playerHealth.health == playerHealth.maxHealth) //If the player has full health
            {
                return false; //Item is not used
            }
            else
            {
                playerHealth.HealHealth(amountToChangeStat); //Activates HealHealth method in PlayerHealth Scipt with amount to change as the 'potency' of the item
                return true; //Item is used
            }
        }
        return false; //If item does not affect health, it cannot be used
    }



    public enum StatToChange //The stats that an object can change
    {
        none, health
    };




}
