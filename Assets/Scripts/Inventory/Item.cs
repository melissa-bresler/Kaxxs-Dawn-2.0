using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour//, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")] //Allows activation of method in Unity Inspector
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString(); //Generates a unique id
    }

    private bool collected = false;


    [SerializeField] public string itemName;
    [SerializeField] public int quantity;
    [SerializeField] public Sprite sprite;
    [TextArea][SerializeField] public string itemDescription;

    public ItemSO itemData;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>(); //Locates correct object and assigns it to variable
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player") //If the player collides with the object
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription, itemData); //Adds item to inventory and checks how much is left over after collection

            if (leftOverItems <= 0) //If there are no more items of this type to collect
            {
                collected = true;
                Destroy(gameObject); //Destroys the object inside the game
            }
            else
            {
                quantity = leftOverItems; //Changes the value of the item to what could not be collected
            }

            Debug.Log("ITEM DATA: \n itemName: " + itemName + "\n quantity: " + quantity + "\n sprite: " + sprite + "\n itemDescription: " + itemDescription + "\n itemData: " + itemData);
        }
    }
    //TODO: Clean up later!!!
    /*
    public void LoadData(GameData data)
    {
        data.itemsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.itemsCollected.ContainsKey(id))
        {
            data.itemsCollected.Remove(id);
        }
        data.itemsCollected.Add(id, collected);
    }
    */
}
