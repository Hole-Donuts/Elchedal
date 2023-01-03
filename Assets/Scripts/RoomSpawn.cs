using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public int _openingDirection;
    public Transform _PosSpawnPrefab;
    private RoomManager _roomTemplates;
    private int _Rand;
    bool _Spawned = false;

    private void Start()
    {
        _roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomManager>();
        Invoke("Spawn", 0.1f);
        _PosSpawnPrefab = GameObject.Find("Spawn Prefab").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Spawn()
    {
        if (_Spawned == false)
        {
            if (_openingDirection == 1)
            {
                _Rand = Random.Range(0, _roomTemplates._bottomRooms.Length);
                Instantiate(_roomTemplates._bottomRooms[_Rand], transform.position, _roomTemplates._bottomRooms[_Rand].transform.rotation, _PosSpawnPrefab);
            }
            else if (_openingDirection == 2)
            {
                _Rand = Random.Range(0, _roomTemplates._topRooms.Length);
                Instantiate(_roomTemplates._topRooms[_Rand], transform.position, _roomTemplates._topRooms[_Rand].transform.rotation, _PosSpawnPrefab);
            }
            else if (_openingDirection == 3)
            {
                _Rand = Random.Range(0, _roomTemplates._leftRoom.Length);
                Instantiate(_roomTemplates._leftRoom[_Rand], transform.position, _roomTemplates._leftRoom[_Rand].transform.rotation, _PosSpawnPrefab);
            }
            else if (_openingDirection == 4)
            {
                _Rand = Random.Range(0, _roomTemplates._rightRooms.Length);
                Instantiate(_roomTemplates._rightRooms[_Rand], transform.position, _roomTemplates._rightRooms[_Rand].transform.rotation, _PosSpawnPrefab);
            }
            _Spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
            if (collision.GetComponent<RoomSpawn>()._Spawned == false && _Spawned == false)
            {
                Instantiate(_roomTemplates._closeRoom, transform.position, Quaternion.identity, _PosSpawnPrefab);
                Destroy(gameObject);
            }
        _Spawned = true;
    }

}
