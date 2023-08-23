using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyMove enemyMove;

    public int currentHealth;
    public int maxHealth = 5;

    private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth; //On loading, the enemy has max health
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; //Damaged by amount i.e. attack power

        if (currentHealth <= 0) //If the health reaches zero
        {
            Destroy(gameObject);
        }
        else
        {
            anim.SetTrigger("isInjured"); //Animation for the user to see their attack was successful
        }
    }
}
