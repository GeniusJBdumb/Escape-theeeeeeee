using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every item has name and an individual image and gets pick up when object collides with player
public interface IInventoryItem {
    string Name { get; } // name of item
    Sprite Image { get; } // image of item which gets displayed in inventory
    void OnPickup(); // is called when item is picked up from scene
    void OnDrop(); // when player drops item in scene
}

// inventory will raise events when an event is raised
public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item; // give the event an item
}

