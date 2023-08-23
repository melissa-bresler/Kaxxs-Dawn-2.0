using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Item Data
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    [SerializeField] public int maxNumberOfItems;

    public ItemSO itemData;

    //Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //Item Description Slot
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite, string itemDescription, ItemSO itemData)
    {
        //Check if slot is already full
        if (isFull)
        {
            return quantity;
        }

        //Update name
        this.itemName = itemName;

        //Update image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;

        //Update description
        this.itemDescription = itemDescription;

        this.itemData = itemData;

        //Update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            //Return the leftovers
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;


        return 0;

    }

    public void OnPointerClick(PointerEventData eventData) //Checking which mouse button was clicked
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnRightClick() //Drop Item
    {
        if (this.quantity != 0)
        {
            //Drop the item
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 offset = new Vector3(1f, 0, 0);
            Quaternion playerRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
            Instantiate(itemData.itemPrefab, playerPosition + offset, playerRotation);

            //Subtract the item from the inventory
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }

    private void OnLeftClick()
    {
        if (thisItemSelected)
        {
            if (this.quantity != 0) //Checks if there is an item in the slot
            {
                bool usable = inventoryManager.UseItem(itemName); //Checks if the item is usable

                if (usable) //Uses item
                {
                    //Decrements the quantity
                    this.quantity -= 1;
                    quantityText.text = this.quantity.ToString();

                    if (this.quantity <= 0) //If there are no more items of the same type in the slot
                    {
                        EmptySlot();
                    }
                }
            }
            
        }
        else //Selects clicked slot. Displays info in description section of inventory
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
        }
    }

    private void EmptySlot() //Resets slot data
    {
        quantityText.enabled = false;
        itemImage.sprite = null;
        itemImage.enabled = false;

        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = null;
        itemDescriptionImage.enabled = false;
    }
}
