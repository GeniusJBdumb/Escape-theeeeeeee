using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    private const int SLOTS = 10; // have every time fixed 10 slots
    private List<IInventoryItem> mItems = new List<IInventoryItem>(); // list for the items in inventory
    
    public event EventHandler<InventoryEventArgs> ItemAdded; // ItemAdded as function to add items to list
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    
    
    // function to add items
    public void AddItem(IInventoryItem item)
    {
        // if there are free slots
        if(mItems.Count < SLOTS)
        {
            // if there is a collision with an item            
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false; // can not collide anymore
                mItems.Add(item); // add item to list
                item.OnPickup(); // pick up item 


                // say all involved parties that need to now about event that something happened
                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
                Debug.Log("added Item to list");
            }
        }
    }

    // function to remove items
    public void RemoveItem(IInventoryItem item)
    {
        // if there is an item in the slow slots
        if(mItems.Contains(item))
        {
            // remove itemimage from inventorylist and drop item in scene
            mItems.Remove(item);
            item.OnDrop();

            // if there is a collision with an item            
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true; // enable the item in the scene again
            }
            
            // say all involved parties that need to now about event that something happened
            if(ItemRemoved != null)
            {            
                ItemRemoved(this, new InventoryEventArgs(item));
            }
            Debug.Log("removed Item to list");
        }
    }
      
}
