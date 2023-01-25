using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomManager _roomTemplates;


    // Start is called before the first frame update
    void Start()
    {
        _roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomManager>();
        _roomTemplates._rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
