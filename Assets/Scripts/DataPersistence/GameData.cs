using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Vector3 playerPosition;
    public Vector3 playerRotation;

    public Dictionary<string, bool> itemsCollected;

//save camera data here?


    public GameData()
    {
        this.maxHealth = 10;
        this.health = this.maxHealth;
        playerPosition = new Vector3(-21.57f, 0.1f, 3.88f);
        playerRotation = new Vector3(0, 0, 180); //z,x,y


        itemsCollected = new Dictionary<string, bool>();
    }
}
