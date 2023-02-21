using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelete : MonoBehaviour
{
   private InventoryManager _inventory;
   private InventoryItem _item;
   private void Awake()
   {
      _inventory = GameObject.Find("Player").GetComponent<InventoryManager>();
   }

   public void DeleteItem()
   {
      _inventory.RemoveItem(_item);
   }
}
