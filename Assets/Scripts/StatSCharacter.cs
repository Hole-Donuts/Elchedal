using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="StatsCharacter",menuName ="Stats Character")]
public class StatSCharacter : ScriptableObject
{
    [Header("Basic Variable Enemy")]
    public string _EnemyName;
    public float _Health;
    public float _Speed;
    public float _Distance;
    public float _Attackrange;
    public float _AttackCooldown;
    public LayerMask _LayerMask;

    [Header("Variable For Ranged Enemy")]
    public GameObject _Projectile;
}
