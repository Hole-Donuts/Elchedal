using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class UiInventoryItem : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TMP_Text _textMeshPro;

    [SerializeField]
    private Image _BorderImage;

    public event Action<UiInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRigtMouseClick;
    private bool _Empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this._image.gameObject.SetActive(false);
        _Empty = true;
    }

    public void Deselect()
    {
        _BorderImage.enabled = false;
    }

    public void SetData(Sprite _sprite,int _Quantity)
    {
        this._image.gameObject.SetActive(true);
        this._image.sprite = _sprite;
        this._textMeshPro.text = _Quantity + "";
        _Empty = false;
    }

    public void Select()
    {
        _BorderImage.enabled = true;
    }

    public void OnBeginDrag()
    {
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData _EventData)
    {
        if (_Empty)
            return;
        PointerEventData _PointerEvent =(PointerEventData)_EventData;
        if (_PointerEvent.button == PointerEventData.InputButton.Right)
        {
            OnRigtMouseClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
