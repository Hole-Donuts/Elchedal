using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory Item Data")]
public class InventoryItemData :ScriptableObject
{
    public string _ID;
    public string _Name;
    public Sprite _Icon;
    public GameObject _Prefabs;
}
