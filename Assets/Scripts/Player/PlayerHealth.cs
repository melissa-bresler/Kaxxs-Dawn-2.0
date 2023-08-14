using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour, IDataPersistence
{
    //public PlayerMovement playerMovement;

    public int health;
    public int maxHealth;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            anim.SetTrigger("isDead");

            //TODO: Disable player movement.
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
        //TODO: Add end of game stuff here.
    }

    public void LoadData(GameData data)
    {
        this.maxHealth = data.maxHealth;
        this.health = data.health;
        Debug.Log("Loading player Max health data: " + this.maxHealth);
        Debug.Log("Loading player Health data: " + this.health);
    }

    public void SaveData(GameData data) //ref
    {
        data.maxHealth = this.maxHealth;
        data.health = this.health;
    }
}
