using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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


    public int AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite, string itemDescription)
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
        if(eventData.button == PointerEventData.InputButton.Left) //Is this usinng the old imput system?
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            inventoryManager.UseItem(itemName);
            //Debug.Log("Item used.");
        }

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
