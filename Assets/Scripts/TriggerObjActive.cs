using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjActive : MonoBehaviour
{

    public GameObject objToActive;

    private void OnTriggerEnter(Collider other)
    {
           if(other.gameObject.tag == "Player")
        {
            objToActive.SetActive(true);
            Destroy(gameObject);
        }
    }
}
