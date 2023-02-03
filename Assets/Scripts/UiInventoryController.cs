using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage _UiInventory;

    public int _InventorySize;

    public void Start()
    {
        _UiInventory.InitializeInventoryUi(_InventorySize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_UiInventory.isActiveAndEnabled == false)
            {
                _UiInventory.ActiveUi();
            }
            else
            {
                _UiInventory.InactiveUi();
            }
        }
    }
}
