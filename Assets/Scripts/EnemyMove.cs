using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform player;

    private NavMeshAgent agent;

    private float enemyDistance = 2.0f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
    }

    //Call every frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        //Look at the player
        transform.LookAt(player); //Too fast. Needs a delay so player can try and move around the enemy.

        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.position) < enemyDistance)
        {
            //Debug.Log("Enemy attack.");
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            gameObject.GetComponent<Animator>().Play("Attack"); //This also needs a delay. Give the player a chance to fight back after an attack.
        }

        //Debug.Log("Distance: " + Vector3.Distance(transform.position, player.position));
    }
}
