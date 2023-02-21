using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerClickHandler
{
    public GameObject selected;
    public InventoryItem item;
    private Image image;
    private RectTransform rect;
    InventoryUi inventoryUi;
    Transform originalparent;
    [SerializeField]
    private GameObject drawcardPanel;

    public InventoryManager _inventoryManager;
    [SerializeField]
    private UiDescription _uiDescription;

    public GameObject delete;
    //ketika mulai di drag object 
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (drawcardPanel.activeInHierarchy==true)
        {
            image.color = Color.gray;
            originalparent = transform.parent; 
            rect.SetAsLastSibling();
        }
    }

    //saat object sedang di drag
    public void OnDrag(PointerEventData eventData)
    {
        if (drawcardPanel.activeInHierarchy==true)
        rect.anchoredPosition += eventData.delta;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
       swapItem();
    }

    //swap posisi object
    public void swapItem()
    {
        bool IsDropped = false;
        if (drawcardPanel.activeInHierarchy == true)
        {
            foreach(GameObject slot in inventoryUi._Slot)
            {
                if (slot.GetComponent<RectTransform>().rect.Contains(slot.transform.InverseTransformPoint(Input.mousePosition)))
                {
                    if (slot.transform.childCount > 0)
                    {
                        Transform currentchild = slot.transform.GetChild(0);
                        currentchild.SetParent(originalparent);
                        currentchild.localPosition = Vector3.zero;
                    }
                    gameObject.transform.SetParent(slot.transform, false);
                    gameObject.transform.localPosition = Vector3.zero;

                    IsDropped = true;
                    break;
                }
            }
            if (!IsDropped)
            {
                gameObject.transform.SetParent(originalparent,false);
                gameObject.transform.localPosition = Vector3.zero;
            }
            image.color = Color.white;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (drawcardPanel.activeInHierarchy == true)
        {
        _uiDescription.ActiveUi();
        _uiDescription.SetDataDescription(item.ItemIcon, item.NameObject, item.Description);
        }

        if (eventData.button==PointerEventData.InputButton.Right){}

        {
            delete.SetActive(true);

        }
    }

    public void removeItem()
    {
        _inventoryManager.RemoveItem(item);
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        inventoryUi = GameObject.Find("Inventory").GetComponent<InventoryUi>();
        drawcardPanel = GameObject.Find("Panel UI");
        _uiDescription = GameObject.Find("Description UI").GetComponent<UiDescription>();
        _inventoryManager = GameObject.Find("Player").GetComponent<InventoryManager>();
        
    }

    
}