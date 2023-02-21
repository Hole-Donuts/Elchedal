using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiDescription : MonoBehaviour
{
    public GameObject PanelDescription;
    public Image imageItem;
    public TextMeshProUGUI TextitemName, TextDescription;

    public void Awake()
    {
       PanelDescription.SetActive(false);
    }

    public void ResetData()
    {
        
        imageItem.gameObject.SetActive(false);
        TextitemName.text = "";
        TextDescription.text = "";
    }
    
    public void SetDataDescription(Sprite sprite, string ItemName, string itemDescription)
    {
        imageItem.gameObject.SetActive(true);
        imageItem.sprite = sprite;
        TextitemName.text = ItemName;
        TextDescription.text = itemDescription;
    }

    public void ActiveUi()
    {
        PanelDescription.SetActive(true);
    }
}
