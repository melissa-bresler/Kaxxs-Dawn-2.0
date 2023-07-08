using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public EnemyMove enemyMove;
    public int damage = 2;

    public PlayerMovement playerMovement;
    bool isBlocking = false;

    public void DamageUpdate()
    {
        isBlocking = playerMovement.GetComponent<PlayerMovement>().GetIsBlocking();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(enemyMove.GetComponent<EnemyMove>().GetIsAttacking())
        if (collision.gameObject.tag == "Player")
        {
            //if (!isBlocking)
            //{
                playerHealth.TakeDamage(damage);
                Debug.Log("Player takes damage.");
            //}
        }
    }
    

    //No damage taken if player is blocking
}
