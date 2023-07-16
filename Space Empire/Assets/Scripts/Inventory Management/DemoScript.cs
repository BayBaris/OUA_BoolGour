using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if(result == true) 
        {
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Item NOT Added!");
        }
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if(receivedItem != null)
        {
            Debug.Log("Received Item: " + receivedItem);
        }
        else
        {
            Debug.Log("No Item Received!");
        }
    }

    public void UseSelectedItem()
    {
        Item usedItem = inventoryManager.GetSelectedItem(true);
        if (usedItem != null)
        {
            Debug.Log("Used Item: " + usedItem);
        }
        else
        {
            Debug.Log("No Item Used!");
        }
    }
}
