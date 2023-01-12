using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 _NewCamPos, _NewPlayerPos;
    CamFollow _CamFollow;

    // Start is called before the first frame update
    void Start()
    {
        _CamFollow = Camera.main.GetComponent<CamFollow>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _CamFollow._MinPos += _NewCamPos;
            _CamFollow._MaxPos += _NewCamPos;

            collision.transform.position += _NewPlayerPos;
        }
    }
}
