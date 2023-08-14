using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public int maxHealth;
    public Vector3 playerPosition;
    //public Vector3 playerRotation;

    //public Dictionary<string, bool> itemsCollected;
    public bool hasSavedData;


    public GameData()
    {
        this.maxHealth = 10; //Changing this doesn't change hearts on screen!
        this.health = this.maxHealth;
        playerPosition = new Vector3(-21.57f, 0.1f, 3.88f);
        //playerRotation = new Vector3(0, 0, 180); //z,x,y


        //itemsCollected = new Dictionary<string, bool>();
    }



    public void SetHasSavedData()
    {
        hasSavedData = true;
    }

    public bool GetHasSavedData()
    {
        return hasSavedData;
    }
}
