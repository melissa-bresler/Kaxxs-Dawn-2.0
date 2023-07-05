using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 5;

    //private Animator anim;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //Play death animation here
            //Add in death animation to animator
            //anim.SetBool("isBlocking", false);

            Destroy(gameObject);
        }
    }
}
