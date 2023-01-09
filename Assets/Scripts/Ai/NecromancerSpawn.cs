using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerSpawn : MonoBehaviour
{
    [SerializeField] private BossNecromancer _boss;
    [SerializeField] GameObject[] _Enemies;
    [SerializeField] Transform _PosPoints;
    private int _RandomSpawnEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        _RandomSpawnEnemy = Random.Range(0, _Enemies.Length);
    }

    public void SpawnEnemy()
    {
        if (_boss._Spawn)
        {
            Instantiate(_Enemies[_RandomSpawnEnemy], _PosPoints.position, Quaternion.identity);
        }
    }
}
