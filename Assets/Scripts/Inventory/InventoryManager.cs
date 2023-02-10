using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> _Items = new List<InventoryItem>();
    public int _MaxSlot;
    
    public void AddItem(InventoryItem _item)
    {
        if(_Items.Count<_MaxSlot)
        _Items.Add(_item);
    }

    public void RemoveItem(InventoryItem _item)
    {
        _Items.Remove(_item);
    }
}
