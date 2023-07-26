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
            if(obj != null) //Is this okay?
            {
                obj.GetComponent<IControllable>().update();
            }

        }
    }
}
