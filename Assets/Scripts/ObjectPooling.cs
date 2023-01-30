using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling _instance;
    public StatSCharacter _statSCharacter;
    private List<GameObject> _PooledObject=new List<GameObject> ();
    private int _Amount = 10;
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _Amount; i++)
        {
            GameObject _Obj = Instantiate(_statSCharacter._Projectile);
            _Obj.SetActive(false);
            _PooledObject.Add(_Obj);
        }
    }

    public GameObject GetPooled()
    {
        for(int i=0;i < _PooledObject.Count; i++)
        {
            if (!_PooledObject[i].activeInHierarchy)
            {
                return _PooledObject[i];
            }
        }
        return null;
    }
}
