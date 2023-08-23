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

    void OnInventory()
    {
        if (menuActivated) //Displays inventory menu
        {
            Resume();
        }
        else if (!menuActivated) //Hides inventory menu
        {
            Pause();
        }
    }

    void Resume()
    {
        InventoryMenu.SetActive(false); //Disables the object
        Time.timeScale = 1f; //Resumes time
        menuActivated = false;
    }

    void Pause()
    {
        InventoryMenu.SetActive(true); //Enables the object
        Time.timeScale = 0f; //Stops time
        menuActivated = true;

    }

    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName) //Checking if item is usable
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }
        }
        return false;
    }

    public int AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite, string itemDescription, ItemSO itemData)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0) //if item slot is empty or item type has already been collected and still has room in slot
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemData); //num of items left over after filling slot

                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemData);//Recursion until all items are added.
                }

                return leftOverItems;
                
            }
        }

        return quantity;
    }

    public void DeselectAllSlots() //Ensures slots don't stay highlighted after being clicked once
    {
        descriptionImage.enabled = true;

        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

}
