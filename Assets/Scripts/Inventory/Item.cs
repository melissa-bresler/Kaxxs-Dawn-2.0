using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite; //To keep track of the image for the object
    [TextArea][SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                quantity = leftOverItems;
            }
            
            //Debug.Log("Player has collided with an item.");
        }
    }
}
