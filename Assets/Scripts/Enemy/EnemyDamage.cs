using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyMove enemyMove;
    private bool canDamage = true;
    [SerializeField] private int damage = 1;

    //public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider collision)
    {
        bool attacking = enemyMove.GetComponent<EnemyMove>().GetIsAttacking();

        if (attacking)
        {

            if (collision.gameObject.tag == "Player")
            {
                //Debug.Log("STEP 3: " + collision.gameObject.GetComponent<PlayerMovement>().GetIsBlocking());

                if (!collision.gameObject.GetComponent<PlayerMovement>().GetIsBlocking())
                {
                    if (canDamage)
                    {
                        StartCoroutine(DamageCooldown(collision.gameObject));
                    }
                    else
                    {
                        Debug.Log("Can't damage yet. Cooldown active.");
                    }
                    //collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(damage);
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
        player.GetComponentInParent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Player takes damage.");
        canDamage = false;
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }


}