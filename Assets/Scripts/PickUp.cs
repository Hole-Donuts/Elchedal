using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject _ItemButton;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i = 0; i < _inventory._Slots.Length; i++)
            {
                if (_inventory._IsFull[i] == false)
                {
                    _inventory._IsFull[i] = true;
                    Instantiate(_ItemButton, _inventory._Slots[i].transform, false) ;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
