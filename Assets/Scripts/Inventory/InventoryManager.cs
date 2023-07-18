using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryMenu;
    private bool menuActivated;
    private bool state;
    public Image descriptionImage;

    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;


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


    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
                //Debug.Log("Sending request to the ItemSO script.");
            }
        }
        return false;
        //Debug.Log("Inventory Manager is trying to use the item.");
    }



    public int AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite, string itemDescription, ItemSO itemData)
    {
        //Debug.Log("ItemName = " + itemName + ". Quantity= " + quantity + ". Sprite= " + itemSprite);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemData);
                if (leftOverItems > 0)

                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemData);//Recursion until all items are added. CAUSING ERRORS
                    //Debug.Log("Empty slot found. " + leftOverItems + " items left.");
                return leftOverItems;
                
            }
        }
        //Debug.Log("Inventory Manager is trying to add " + itemName);
        return quantity;
    }

    public void DeselectAllSlots()
    {
        descriptionImage.enabled = true;
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}
