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
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.color = Color.gray;
        originalparent = transform.parent;
        rect.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
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
        image.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        inventoryUi = GameObject.Find("Canvas").GetComponent<InventoryUi>();
    }

  
}
