using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    public Inventory Inventory; // reference to the inventory
    
    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded; // to notify itemadded event if item is added
    }

    // function to handle inventory
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        // find the created panel for inventory
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Debug.Log("found panel" + inventoryPanel);
        // loop through all 9 slots
        foreach(Transform slot in inventoryPanel)
        {
            Debug.Log("i am in the loop for the slot running");
            // get the child of the border image i. e. the item image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            // if there is an empty slot i.e. no image
            if(!image.enabled)
            {
                image.enabled = true; // say that there is an image
                image.sprite = e.Item.Image; // actually add the image from the item
                Debug.Log("loop through slost and put in image");
                
                // need to add what happence if store item smth like referecne to object
                break;
            }


        }
    }
    
}
