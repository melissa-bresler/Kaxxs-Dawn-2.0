using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjActive : MonoBehaviour
{

    public GameObject objToActive;

    private void OnTriggerEnter(Collider other)
    {
           if(other.gameObject.tag == "Player") //If collision with player
        {
            objToActive.SetActive(true); //Activates object i.e. enemy
            Destroy(gameObject); //Destorys this game object
        }
    }
}
