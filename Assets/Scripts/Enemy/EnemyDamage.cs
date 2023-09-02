using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyMove enemyMove;
    private bool canDamage = true;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider collision)
    {
        bool attacking = enemyMove.GetComponent<EnemyMove>().GetIsAttacking(); //Finds the state of the enemy i.e. if the attacking animation is playing

        if (attacking)
        {

            if (collision.gameObject.tag == "Player")
            {

                if (!collision.gameObject.GetComponent<PlayerMovement>().GetIsBlocking())
                {
                    if (canDamage) //When the enemy successfully hits the player
                    {
                        StartCoroutine(DamageCooldown(collision.gameObject)); //Invokes coroutine
                    }
                    else //No damage can be inflicted when the player is blocking
                    {
                        Debug.Log("Can't damage yet. Cooldown active.");
                    }
                }
                else
                {
                    Debug.Log("Player is BLOCKING");
                }
            }
        }
    }

    private IEnumerator DamageCooldown(GameObject player)
    {
        player.GetComponentInParent<PlayerHealth>().TakeDamage(damage); //Damages the player
        canDamage = false; //Disables the enemy's ability to damage the player
        yield return new WaitForSeconds(2f); //Waits 2 seconds before continuing
        canDamage = true; //Enables the enemy's ability to damage the player
    }


}