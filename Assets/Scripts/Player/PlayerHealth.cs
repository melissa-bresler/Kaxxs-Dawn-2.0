using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour, IDataPersistence
{
    private PlayerMovement playerMovemenetScript = null;
    public GameObject gameOverUI;

    public int health;
    public int maxHealth;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); //Links animator
        gameOverUI.SetActive(false); //Makes sure Game Over Screen isn't visible at start of game
        playerMovemenetScript = GetComponentInParent<PlayerMovement>(); //Finds correct script from parent object
        playerMovemenetScript.Enabled = true; //Enables player movement when initiating this script

    }

    public void TakeDamage(int amount) //When player is injured
    {
        health -= amount; //Health decrements by amount i.e. enemy's attack power

        if (health <= 0) //If the player is dead
        {
            playerMovemenetScript.Enabled = false; //Disables player movement
            anim.SetTrigger("isDead"); //Plays death animation
            Invoke("EndOfGame", 5f); //Waits 5 seconds before activating the method
        }
        else
        {
            anim.SetTrigger("isInjured"); //Plays injured animation so user has a visual cue that the player has been injured
        }
    }

    public void HealHealth(int amount) //Activated through using a health potion
    {
        if (health < maxHealth) //If the player doesn't have full health
        {
            health += amount; //Health increased by amount i.e. potency of potion
        }
    }

    public void EndOfGame()
    {
        Time.timeScale = 0f; //Stops time so that game doesn't continue after the player dies
        gameOverUI.SetActive(true); //Displays the Game Over screen
    }

    public void LoadData(GameData data) //Copies data from saved file on pc to game
    {
        this.maxHealth = data.maxHealth;
        this.health = data.health;
    }

    public void SaveData(GameData data) //Copies data from game onto saved file on pc
    {
        data.maxHealth = this.maxHealth;
        data.health = this.health;
    }
}
