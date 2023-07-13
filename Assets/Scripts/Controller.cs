using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<IControllable>().update(); //Only grabbing one script for each game object
            //Debug.Log("Update: " + obj.GetComponent<IControllable>());
        }
    }
}
