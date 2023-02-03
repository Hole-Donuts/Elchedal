using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UiInventoryItem _ItemPrefab;

    [SerializeField]
    private RectTransform _ContentPanel;
    
    List<UiInventoryItem> _ListofUiItem=new List<UiInventoryItem>();

   public void InitializeInventoryUi(int _InventorySize)
    {
        for (int i = 0; i < _InventorySize; i++)
        {
            UiInventoryItem _UiItem =
                Instantiate(_ItemPrefab, Vector3.zero, Quaternion.identity);
            _UiItem.transform.SetParent(_ContentPanel);
            _ListofUiItem.Add(_UiItem);
            _UiItem.OnItemClicked += HandleItemSelection;
            _UiItem.OnItemBeginDrag += HandleBeginDrag;
            _UiItem.OnItemDroppedOn += HandleSwap;
            _UiItem.OnItemEndDrag += HandleEndDrag;
            _UiItem.OnRigtMouseClick += HandleShowItemAction;

        }
    }

    private void HandleItemSelection(UiInventoryItem _Obj)
    {

    }

    private void HandleBeginDrag(UiInventoryItem _Obj)
    {

    }

    private void HandleSwap(UiInventoryItem _Obj)
    {

    }

    private void HandleEndDrag(UiInventoryItem _Obj)
    {

    }

    private void HandleShowItemAction(UiInventoryItem _Obj)
    {

    }


    public void ActiveUi()
    {
        gameObject.SetActive(true);
    }

    public void InactiveUi()
    {
        gameObject.SetActive(false);
    }
}
