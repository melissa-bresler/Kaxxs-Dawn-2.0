using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]

public class EnemyHealth : MonoBehaviour
{
    public EnemyMove enemyMove;

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
            //gameObject.SetActive(false); //Causes issues
            //enemyMove.enabled = false; //Doesn't stop enemy from moving
            Debug.Log("Enemy is dead.");

        }
    }
}
