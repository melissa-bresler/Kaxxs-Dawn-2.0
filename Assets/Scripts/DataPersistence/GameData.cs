using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public int maxHealth;
    public Vector3 playerPosition;

    public bool hasSavedData;

    public GameData() //Default values unless otherwise specified
    {
        this.maxHealth = 10;
        this.health = this.maxHealth;
        playerPosition = new Vector3(-21.57f, 0.1f, 3.88f);
    }

    public void SetHasSavedData() //Used to easily identify if a file has been altered from the default values
    {
        hasSavedData = true;
    }

    public bool GetHasSavedData()
    {
        return hasSavedData;
    }
}
