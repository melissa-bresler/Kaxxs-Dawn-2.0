using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour, IDataPersistence
{
    //public PlayerMovement playerMovement;

    public int health;
    public int maxHealth; // = 10 //Changing this doesn't change hearts on screen!

    private Animator anim;

    void Awake() //Changed from start
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
            //Play death animation here
            anim.SetTrigger("isDead");

            //playerMovement.enabled = false;
            Debug.Log("Player is dead. They can no longer move.");

            //Add end screen of whatever else here.
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

            /*if(health > maxHealth)
            {
                health = maxHealth;
                Debug.Log("Player at full health");
            }*/
        }
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
