using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour, IDataPersistence
{
    //public PlayerMovement playerMovement;
    private PlayerMovement playerMovemenetScript = null;
    public GameObject gameOverUI;

    public int health;
    public int maxHealth;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        gameOverUI.SetActive(false); //Makes sure Game Over Screen isn't visible at start of game
        playerMovemenetScript = GetComponentInParent<PlayerMovement>();
        playerMovemenetScript.Enabled = true; //Enables player movement when initiating this script

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            playerMovemenetScript.Enabled = false; //Disables player movement after death
            anim.SetTrigger("isDead");
            Debug.Log("Player is dead. They can no longer move.");
            Invoke("EndOfGame", 5f);
        }
        else
        {
            anim.SetTrigger("isInjured");
        }
    }

    public void HealHealth(int amount)
    {
        if (health < maxHealth)
        {
            health += amount;
            Debug.Log("Health increased by " + amount);
        }
    }

    public void EndOfGame()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void LoadData(GameData data)
    {
        this.maxHealth = data.maxHealth;
        this.health = data.health;
        Debug.Log("Loading player Max health data: " + this.maxHealth + "\n Loading player Health data: " + this.health);
    }

    public void SaveData(GameData data) //ref
    {
        data.maxHealth = this.maxHealth;
        data.health = this.health;
    }
}
