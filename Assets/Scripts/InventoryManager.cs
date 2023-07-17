using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActivated;
    private bool state;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InventoryMenu.SetActive(state);
    }

    void OnInventory()
    {
        //Debug.Log("Inventory button pressed.");
        menuActivated = !menuActivated;

        if (menuActivated)
        {
            state = true;
            Time.timeScale = 0;
        }
        else if (!menuActivated)
        {
            state = false;
            Time.timeScale = 1;
        }
    }
}
