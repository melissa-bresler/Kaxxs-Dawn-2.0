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

    /*private void OnCollisionEnter(Collision collision)
    {
        if(enemyMove.GetComponent<EnemyMove>().GetIsAttacking())
        if (collision.gameObject.tag == "Player")
        {
            //if (!isBlocking)
            //{
                playerHealth.TakeDamage(1); //Change 1 back to 'damage' after testing
                Debug.Log("Player takes damage.");
            //}
        }
    }
    */

    /*
        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log("Enemy collides with the player.");
            if (enemyMove.GetComponent<EnemyMove>().GetIsAttacking())
            {
                if (collision.gameObject.tag == "Player")
                {
                    //if (!isBlocking)
                    //{
                    //playerHealth.TakeDamage(1); //Change 1 back to 'damage' after testing
                    collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(1);
                    Debug.Log("Player takes damage.");
                    //}
                }

                Debug.Log("Enemy is attacking the player.");
            }
        }
    */

    //No damage taken if player is blocking



    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Please work!!!");
    }




}
