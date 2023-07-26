using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjActive : MonoBehaviour
{

    public GameObject objToActive;
    //public GameObject blockEnemy;

    private void OnTriggerEnter(Collider other)
    {
           if(other.gameObject.tag == "Player")
        {
            objToActive.SetActive(true);
            //objToActive.GetComponent<EnemyMove>().enabled = true;
            //Destroy(blockEnemy);
            Destroy(gameObject);
        }
    }
}
