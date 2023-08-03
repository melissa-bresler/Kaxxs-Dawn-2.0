using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    void Update()
    {
        foreach (GameObject obj in objects)
        {
            if(obj != null && obj.activeSelf == true) //Is this okay?
            {
                obj.GetComponent<IControllable>().update();
            }

        }
    }
}
