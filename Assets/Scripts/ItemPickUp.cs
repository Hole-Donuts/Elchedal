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

    [SerializeField] private GameObject pos;
    
    // Start is called before the first frame update
    void Awake()
    {
        _inventoryUi = GameObject.Find("Inventory").GetComponent<InventoryUi>();
        _inventoryManager = GameObject.Find("Player").GetComponent<InventoryManager>();
        panel = GameObject.Find("Panel");
        pos = GameObject.Find("pos");
    }

  

    public void OnPointerClick(PointerEventData eventData)
    {
      
            if (_inventoryManager!=null)
            {
                if (pos.transform.childCount>=3)
                {
                    Destroy(gameObject);
                    _inventoryManager.AddItem(item);
                    _inventoryUi.DisplayItemIcon();
                }
            }
    }
}
