using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every item has name and an individual image and gets pick up when object collides with player
public interface IInventoryItem {
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();
}

// inventory will rais events when an event is raised
public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item; // give the event an item
}

