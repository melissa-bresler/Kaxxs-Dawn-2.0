using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform player;

    private NavMeshAgent agent;

    [SerializeField] float enemyDistance = 2.0f;

    public EnemyDamage enemyDamage;

    private Animator anim;

    private bool isAttacking;

    public PlayerHealth playerHealth;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        enemyDamage = GetComponent<EnemyDamage>();

        anim = GetComponent<Animator>();
    }

    //Call every frame
    void Update()
    {
        MoveEnemy();
        //enemyDamage.DamageUpdate();
    }

    void MoveEnemy()
    {
        //Look at the player
        transform.LookAt(player); //Too fast. Needs a delay so player can try and move around the enemy.

        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.position) < enemyDistance)
        {
            anim.SetInteger("Walk", 0);
            //Debug.Log("Enemy attack.");
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            enemyDistance = 2.5f;
            if (!isAttacking) {
                Invoke("Attack", 2.1f);
            }
        }
        else
        {
            anim.SetInteger("Walk", 1);
            enemyDistance = 2.0f;
        }

        //Debug.Log("Distance: " + Vector3.Distance(transform.position, player.position));
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
