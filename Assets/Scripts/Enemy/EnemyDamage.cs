using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public EnemyMove enemyMove;
    //public int damage = 2;

    public PlayerMovement playerMovement;
    bool isBlocking;

    public void DamageUpdate()
    {
        isBlocking = playerMovement.GetComponent<PlayerMovement>().GetIsBlocking();
    }
    

    private void OnTriggerEnter(Collider collision)
    {
        bool attacking = enemyMove.GetComponent<EnemyMove>().GetIsAttacking();
        //Debug.Log("attacking: " + attacking);
        if(attacking)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (!isBlocking)
                {
                //playerHealth.TakeDamage(1); //Change 1 back to 'damage' after testing
                collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(1);
                //Debug.Log("Player takes damage.");
                }
                else
                {
                    Debug.Log("Player is blocking");
                }
            }

            //Debug.Log("Enemy is attacking the player.");
        }
    }




}
