using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour//, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")] //Allows you to activate method in the inspector in Unity
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool collected = false;


    [SerializeField] public string itemName;
    [SerializeField] public int quantity;
    [SerializeField] public Sprite sprite; //To keep track of the image for the object
    [TextArea][SerializeField] public string itemDescription;

    public ItemSO itemData;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription, itemData);
            if (leftOverItems <= 0)
            {
                collected = true;
                Destroy(gameObject);
            }
            else
            {
                quantity = leftOverItems;
            }

            //Debug.Log("Player has collided with an item.");
            Debug.Log("ITEM DATA: \n itemName: " + itemName + "\n quantity: " + quantity + "\n sprite: " + sprite + "\n itemDescription: " + itemDescription + "\n itemData: " + itemData);
        }
    }
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
