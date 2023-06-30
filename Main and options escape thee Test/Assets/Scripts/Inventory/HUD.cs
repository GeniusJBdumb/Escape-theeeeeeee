using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Heads-Up Display which handels the inventory system and inventory user interface
public class HUD : MonoBehaviour
{
    public Inventory Inventory; // reference to the inventory
    
    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded; // to notify itemadded event if item is added
        Inventory.ItemRemoved += Inventory_ItemRemoved; // to notify itemremoved event if item is removed
    }

    // function to handle inventory adding
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        // find the created panel for inventory
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Debug.Log("found panel" + inventoryPanel);
        
        // loop through all 9 slots
        foreach(Transform slot in inventoryPanel)
        {
            // get the child of the border image i. e. the item image
            Transform imageTransform = slot.GetChild(0).GetChild(0); 
            Image image = imageTransform.GetComponent<Image>();
            
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>(); // get itme draghandler class
            
            // if there is an empty slot i.e. no image
            if(!image.enabled)
            {
                image.enabled = true; // make image of slot visible
                image.sprite = e.Item.Image; // actually add the image from the inventoryslot
                // Debug.Log("loop through slots and put in image");
                
                // store reference to item
                itemDragHandler.Item = e.Item;
                break;
            }
        }
    }

    // function to handle inventory removing
    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        // find the created panel for inventory
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Debug.Log("found panel in drop" + inventoryPanel);
        
        // loop through all 9 slots
        foreach (Transform slot in inventoryPanel)
        {
            // get the child of the border image i. e. the item image
            Transform imageTransform = slot.GetChild(0).GetChild(0); 
            Image image = imageTransform.GetComponent<Image>();
            
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>(); // get item draghandler class
            
            // if there is an item in the UI
            // Note: here you need == the equals() function does not work
            if(itemDragHandler.Item == e.Item)
            {
                image.enabled = false; // make image of slot invisible
                image.sprite = null; // actually remove the image from the inventoryslot
                // Debug.Log("loop through slots and removed image");
                
                // remove  reference to item
                itemDragHandler.Item = null;
                break;
            }
        }
    }
}
