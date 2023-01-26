using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProceduralLevelEvent : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent _CustomEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _CustomEvent.Invoke();
        }
    }
}
