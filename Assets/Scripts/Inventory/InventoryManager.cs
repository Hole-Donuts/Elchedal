using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> _Items = new List<InventoryItem>();
    public int _MaxSlot;

    public InventoryUi _inventoryUi;
    public GameObject inventory;

 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inventory.activeSelf!=true)
            {
                _inventoryUi.ShowInventory();
            }
            else
            {
                _inventoryUi.closeInventory();
            }
        }
    }

    public void AddItem(InventoryItem _item)
    {
        
        if(_Items.Count<_MaxSlot)
        _Items.Add(_item);
        _inventoryUi.DisplayItemIcon();
    }

    public void RemoveItem(InventoryItem _item)
    {
        _Items.Remove(_item);
    }
}
