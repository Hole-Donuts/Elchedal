using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiItem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    
    private Image image;
    private RectTransform rect;
    InventoryUi inventoryUi;
    Transform originalparent;
    private GameObject drawcardPanel;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (drawcardPanel.activeInHierarchy==false)
        {
            image.color = Color.gray;
            originalparent = transform.parent; 
            rect.SetAsLastSibling();
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (drawcardPanel.activeInHierarchy==false)
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (drawcardPanel.activeInHierarchy == false)
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
                }
            }
                gameObject.transform.SetParent(originalparent, false);
            image.color = Color.white;
        }
        
    }
    
  

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        inventoryUi = GameObject.Find("Inventory").GetComponent<InventoryUi>();
        drawcardPanel = GameObject.Find("Panel Card random");
    }
}
