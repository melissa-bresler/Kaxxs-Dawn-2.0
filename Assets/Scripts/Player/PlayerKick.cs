using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    //This should only happen once
    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Player is kicking the enemy.");
        if (collision.gameObject.tag == "WeakPoint")
        {
            collision.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(2);
            Debug.Log("Weak point hit.");
        }
    }
}
