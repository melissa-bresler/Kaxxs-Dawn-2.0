using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerHealth : MonoBehaviour
{
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

            //Add end screen of whatever else here.

            //Destroy(gameObject);
        }
    }
}
