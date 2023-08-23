using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "WeakPoint") //If collision with enemy's weak point
        {
            collision.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(2); //Damages enemy
        }
    }
}
