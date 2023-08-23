using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    void Update() //Ensures only Update is called on objects that require updating with each frame.
    {
        foreach (GameObject obj in objects)
        {
            if(obj != null && obj.activeSelf == true)
            {
                obj.GetComponent<IControllable>().update();
            }

        }
    }
}
