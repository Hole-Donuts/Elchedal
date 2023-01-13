using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNecromancer : enemy
{
    [Header("Ranged Attack Variable")]

    [SerializeField] Transform _ProjectilePos;

    [Header("Boss Variable")]
    public bool _Spawn = false;
    [SerializeField] float _TimeToSpawn;
    float _Timers;

    private void Update()
    {
        if (Vector2.Distance(transform.position, _Target.position) > _StatusCharacter._Attackrange)
        {
            Move();
        }
        else if (Vector2.Distance(transform.position, _Target.position) <_StatusCharacter._Attackrange)
        {
            Attack();
            MoveStop();
        }

        if (_Spawn)
            _Spawn = false;

        SpawnEnemy();
        TurnDirection();
    }

    protected override void Move()
    {

        base.Move();
    }

    protected override void MoveStop()
    {

        base.MoveStop();
    }

    protected override void TurnDirection()
    {
        base.TurnDirection();
    }

    public void Attack()
    {
        _CooldownTimer += Time.deltaTime;
        if (_CooldownTimer >= _StatusCharacter._AttackCooldown)
        {
            Instantiate(_StatusCharacter._Projectile, _ProjectilePos.position, Quaternion.identity);
            _CooldownTimer = 0;
            _animator.SetTrigger("Attack");
        }
    }

    public void SpawnEnemy()
    {
        _Timers += Time.deltaTime;
        Debug.Log(_Timers);
        if (_Timers >= _TimeToSpawn)
        {
            _Spawn = true;
            _Timers = 0;
        }
    }

    void Shoot()
    {
        RaycastHit2D _shootrange = Physics2D.CircleCast(transform.position, _StatusCharacter._Attackrange, Vector2.zero, _StatusCharacter._LayerMask);
        if (_shootrange.collider.gameObject.tag == "Player")
        {
            Debug.Log("ada player");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _StatusCharacter._Attackrange);
    }
}
