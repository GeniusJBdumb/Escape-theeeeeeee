// for dropping items somewhere in the scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    
    public Inventory _Inventory; // reference to inventory
    // to sto check if item has been droped out of inventorypanel
    public void OnDrop(PointerEventData eventData)
    {
        // get the inventorypanel
        RectTransform invPanel = transform as RectTransform;
        // check if the current mouscoordinates are inside the rectangle of the inventorypanel
        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Mouse.current.position.ReadValue())) 
        {
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
            if(item != null)
            {
                _Inventory.RemoveItem(item);
                item.OnDrop();
            }
        }
    }
}
