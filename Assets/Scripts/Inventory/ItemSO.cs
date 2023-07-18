using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;



    public void UseItem()
    {
        if(statToChange == StatToChange.health)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().HealHealth(amountToChangeStat);
            //Debug.Log("SO is trying to use the item and increase the Player's health.");
        }
    }



    public enum StatToChange
    {
        none, health
    };




}
