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
    //public Sprite emptySprite; //Uncomment once you've added an empty sprite
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
        //Debug.Log("Item added to inventory");

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
        //Debug.Log("Image enabled");

        //Update description
        this.itemDescription = itemDescription;

        this.itemData = itemData;

        //Update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            //Debug.Log("Text enabled");
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

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) //Is this using the old imput system?
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
            GameObject itemToDrop = new GameObject(itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.quantity = 1;
            newItem.itemName = itemName;
            newItem.sprite = itemSprite;
            newItem.itemDescription = itemDescription;


            //Drop the item
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 offset = new Vector3(1f, 0, 0); //Will always spawn to the right
            Quaternion playerRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation; //this doesn't seem to be doing anything
            Instantiate(itemData.itemPrefab, playerPosition + offset, playerRotation);


            //Set location
            //itemToDrop.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0.5f, 0, 0);

            //Subtract the item
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            if (this.quantity != 0) //Stops player from using an item they've already dropped/used
            {
                bool usable = inventoryManager.UseItem(itemName);
                if (usable)
                {
                    //Debug.Log("Item used.");
                    this.quantity -= 1;
                    quantityText.text = this.quantity.ToString();
                    if (this.quantity <= 0)
                    {
                        EmptySlot();
                    }
                }
            }
            
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;

            //Uncomment once you've added an empty sprite
            /*if(itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
            */
        }
    }

    private void EmptySlot()
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
