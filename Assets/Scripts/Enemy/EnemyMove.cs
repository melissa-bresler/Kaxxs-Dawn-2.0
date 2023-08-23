using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour, IControllable
{
    private Transform player;

    private NavMeshAgent agent;

    [SerializeField] float enemyDistance = 2.0f;

    public EnemyDamage enemyDamage;

    private Animator anim;

    private bool isAttacking;

    private void Start() //Finds needed components for script to function
    {
        player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        enemyDamage = GetComponent<EnemyDamage>();

        anim = GetComponent<Animator>();
    }

    public void update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        //Look at the player
        transform.LookAt(player);

        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.position) < enemyDistance) //If the enemy is within distance of player
        {
            //Enemy stops walking
            anim.SetInteger("Walk", 0);
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            enemyDistance = 2.5f;

            //Enemy attacks player
            if (!isAttacking) {
                isAttacking = true;
                Invoke("Attack", 2.1f);
            }
        }
        else //Walk towards player
        {
            anim.SetInteger("Walk", 1);
            enemyDistance = 2.0f;
        }
    }

    void Attack()
    {
        anim.SetTrigger("isAttacking");
        Invoke("ResetAttacking", 4.2f);
    }

    void ResetAttacking()
    {
        isAttacking = false;
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }
}
