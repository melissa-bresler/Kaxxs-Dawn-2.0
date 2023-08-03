using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour, IDataPersistence
{
    //public PlayerMovement playerMovement;

    public int health;
    public int maxHealth = 10;

    private Animator anim;

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
            //Add in death animation to animator
            //anim.SetBool("isBlocking", false);

            //playerMovement.enabled = false;
            Debug.Log("Player is dead. They can no longer move.");

            //Add end screen of whatever else here.
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
    }

    public void SaveData(ref GameData data)
    {
        data.maxHealth = this.maxHealth;
        data.health = this.health;
    }
}
