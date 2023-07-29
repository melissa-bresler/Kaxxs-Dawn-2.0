using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyMove enemyMove;
    //public int damage = 2;

    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider collision)
    {
        bool attacking = enemyMove.GetComponent<EnemyMove>().GetIsAttacking();

        if (attacking)
        {

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("STEP 3: " + collision.gameObject.GetComponent<PlayerMovement>().GetIsBlocking());

                if (!collision.gameObject.GetComponent<PlayerMovement>().GetIsBlocking())
                {
                    collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(1); //Change 1 back to 'damage' after testing
                }
                else
                {
                    Debug.Log("Player is BLOCKING");
                }
            }
        }
    }




}
