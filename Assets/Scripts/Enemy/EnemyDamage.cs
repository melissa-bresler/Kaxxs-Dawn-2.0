using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public EnemyMove enemyMove;
    //public int damage = 2;

    //public PlayerMovement playerMovement;
    //bool isBlocking = false;

    /*public void DamageUpdate()
    {
        isBlocking = playerMovement.GetComponent<PlayerMovement>().GetIsBlocking();
    }
    */

    //No damage taken if player is blocking

    private void OnTriggerEnter(Collider collision)
    {
        bool attacking = enemyMove.GetComponent<EnemyMove>().GetIsAttacking();
        //Debug.Log("attacking: " + attacking);
        if(attacking)
        {
            if (collision.gameObject.tag == "Player")
            {
                //if (!isBlocking)
                //{
                //playerHealth.TakeDamage(1); //Change 1 back to 'damage' after testing
                collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(1);
                //Debug.Log("Player takes damage.");
                //}
            }

            //Debug.Log("Enemy is attacking the player.");
        }
    }




}
