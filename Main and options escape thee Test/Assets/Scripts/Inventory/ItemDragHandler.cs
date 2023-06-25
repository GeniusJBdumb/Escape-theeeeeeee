// script that implements dragfunction of objects out of inventory
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    private InputManager inputManager; // reference to input manager NO NEED??????
    public IInventoryItem Item {get; set;} // reference to inventoryitem e.g. fireextinguisher

    // to start on drag function
    public void OnDrag(PointerEventData eventData)
    {
        // position of transform (itemimage in inventory) being mousecursor
        transform.position = Mouse.current.position.ReadValue();
    }
    

    // when ondrag operation is finished
    public void OnEndDrag(PointerEventData eventData)
    {
        // reset position of itemimage
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log(Item.Name);
    }
    
}
