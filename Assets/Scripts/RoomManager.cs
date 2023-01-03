using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
   
    public GameObject[] _bottomRooms;
    public GameObject[] _topRooms;
    public GameObject[] _leftRoom;
    public GameObject[] _rightRooms;

    public GameObject _closeRoom;

    public List<GameObject> _rooms;
    public Transform _PosSpawnPrefab;
    public float _waitTime;
    private bool _SpawnedBoss;
    public GameObject _boss, _enemy;
    public GameObject _blacksmith, _chesstreasure;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_waitTime <= 0 && _SpawnedBoss == false)
        {

            for (int i = 0; i < _rooms.Count; i++)
            {
                if (i == _rooms.Count - 1)
                {
                    Instantiate(_boss, _rooms[i].transform.position, Quaternion.identity, _PosSpawnPrefab);
                    _SpawnedBoss = true;
                }
            }

            for (int i = 0; i < _rooms.Count; i++)
            {
                if (i != _rooms.Count - 1 && i != _rooms.Count - 5 && i != _rooms.Count - 3 && i != _rooms.Count - 10)
                {
                    Instantiate(_enemy, _rooms[i].transform.position, Quaternion.identity, _PosSpawnPrefab);
                    _SpawnedBoss = true;
                }
            }

            for (int i = 0; i < _rooms.Count; i++)
            {
                if (i == _rooms.Count - 5)
                {
                    Instantiate(_blacksmith, _rooms[i].transform.position, Quaternion.identity,_PosSpawnPrefab);
                }
            }

            for (int i = 0; i < _rooms.Count; i++)
            {
                if (i == _rooms.Count - 3)
                {
                    Instantiate(_chesstreasure, _rooms[i].transform.position, Quaternion.identity, _PosSpawnPrefab);
                }
            }

            for (int i = 0; i < _rooms.Count; i++)
            {
                if (i == _rooms.Count - 10)
                {
                    Instantiate(_chesstreasure, _rooms[i].transform.position, Quaternion.identity, _PosSpawnPrefab);
                }
            }
        }
        else
        {
            _waitTime -= Time.deltaTime;
        }
    }
}

