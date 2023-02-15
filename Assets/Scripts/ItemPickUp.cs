using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickUp : MonoBehaviour,IPointerClickHandler
{
    public InventoryItem item;
    
    [SerializeField]
    private InventoryUi _inventoryUi;

    [SerializeField]
    private InventoryManager _inventoryManager;

    [SerializeField] 
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        _inventoryUi = GameObject.Find("Inventory").GetComponent<InventoryUi>();
        _inventoryManager = GameObject.Find("Player").GetComponent<InventoryManager>();
        panel = GameObject.Find("Panel");
    }

  

    public void OnPointerClick(PointerEventData eventData)
    {
        if (panel.activeInHierarchy==false)
        {
            if (_inventoryManager!=null)
            {
                Destroy(gameObject);
                _inventoryManager.AddItem(item);
                _inventoryUi.DisplayItemIcon();
            }
            
        }
       
    }
}
