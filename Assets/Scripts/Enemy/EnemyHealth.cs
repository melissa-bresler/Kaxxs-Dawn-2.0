using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyMove enemyMove;

    public int currentHealth;
    public int maxHealth = 5;

    //TODO: Insert animator and injury animation?
    //private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth; //On loading, the enemy has max health
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; //Damegd by amount i.e. attack power

        if (currentHealth <= 0) //If the health reaches zero
        {
            Destroy(gameObject);
        }
        else
        {
            //Injury animation here?
        }
    }
}
