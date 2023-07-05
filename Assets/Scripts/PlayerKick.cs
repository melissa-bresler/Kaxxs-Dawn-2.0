using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player is kicking the enemy.");
        if (collision.gameObject.tag == "WeakPoint")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            Debug.Log("Weak point hit.");
        }
    }
}
