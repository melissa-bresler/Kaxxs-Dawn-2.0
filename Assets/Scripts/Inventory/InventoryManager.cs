using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActivated;
    private bool state;

    public ItemSlot[] itemSlot;


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


    public int AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite, string itemDescription)
    {
        //Debug.Log("ItemName = " + itemName + ". Quantity= " + quantity + ". Sprite= " + itemSprite);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)

                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);//Recursion until all items are added. CAUSING ERRORS
                    Debug.Log("Empty slot found. " + leftOverItems + " items left.");
                return leftOverItems;
                
            }
        }
        //Debug.Log("Inventory Manager is trying to add " + itemName);
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}
