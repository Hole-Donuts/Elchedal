using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public int maxCard = 3;
    public Transform canvas;
    public void Start()
    {
        
        SPawn();
    }
    public void Update()
    {
        
    }

    void SPawn()
    {
        
        for(int i = 0; i < maxCard; i++)
        {
            int n = Random.Range(0,prefabs.Count-1);
            Instantiate(prefabs[n], transform.position,Quaternion.identity,canvas);
            Debug.Log(n);
        }
    }
}
