using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    //Item Data
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;



    //Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;


    public void AddItem(string itemName, int quantity, UnityEngine.Sprite itemSprite)
    {
        Debug.Log("Item added to inventory");

        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;


        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        Debug.Log("Text enabled");

        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        if(itemImage.enabled == true)
        {
            Debug.Log("Image enabled");
        }
    }
}
