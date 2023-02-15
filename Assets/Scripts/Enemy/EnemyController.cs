using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageAble
{
    public void Damaged(float _damage)
    {
        Debug.Log($"kena damage {_damage}");
    }
}