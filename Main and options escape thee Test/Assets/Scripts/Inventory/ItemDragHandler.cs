// script that implements dragfunction of objects out of inventory
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
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
        TextMeshProUGUI infoline = GameObject.Find("InfoLine").GetComponent<TextMeshProUGUI>();
        infoline.text = Item.Name;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        TextMeshProUGUI infoline = GameObject.Find("InfoLine").GetComponent<TextMeshProUGUI>();
        infoline.text = "";
    }

}
