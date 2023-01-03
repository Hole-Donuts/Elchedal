using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject gameObject;

    private void Awake()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
