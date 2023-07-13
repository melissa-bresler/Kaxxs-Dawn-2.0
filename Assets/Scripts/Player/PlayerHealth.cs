using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour
{
    public PlayerMovement playerMovement;

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
}
