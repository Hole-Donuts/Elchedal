using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public GameObject _PrefabSlot;
    public Transform _ParentSlot;
    public GameObject _UiInventory;

    InventoryManager _InventoryManager;
    public List<GameObject> _Slot = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _InventoryManager = GameObject.Find("Player").GetComponent<InventoryManager>();
        iniateSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void iniateSlot()
    {
        for(int i = 0; i < _InventoryManager._MaxSlot; i++)
        {
            GameObject ItemSlot = Instantiate(_PrefabSlot);
            ItemSlot.transform.SetParent(_ParentSlot, false);
            _Slot.Add(ItemSlot);
        }
        DisplayItemIcon();
    }
    

    public void DisplayItemIcon()
    {
        for(int i = 0; i < _Slot.Count; i++)
        {
            GameObject iconItem = Instantiate(_InventoryManager._Items[i]._Icon);
            iconItem.transform.SetParent(_Slot[i].transform, false);
        }
    }
}
