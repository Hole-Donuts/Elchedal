using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Archer : enemy
{
    [Header("Ranged Attack Variable")]
    [SerializeField] Transform _ProjectilePos;
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

    public void Attack()
    {
        _CooldownTimer += Time.deltaTime;
        if (_CooldownTimer >= _StatusCharacter._AttackCooldown)
        {
            GameObject bullet = ObjectPooling._instance.GetPooled();
            if (!bullet != null)
            {
                bullet.transform.position = _ProjectilePos.position;
                bullet.SetActive(true);
            }
            _CooldownTimer = 0;
            _animator.SetTrigger("Attack");
        }
    }

    protected override void TurnDirection()
    {
        base.TurnDirection();
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
        Gizmos.DrawWireSphere(transform.position,_StatusCharacter._Attackrange);
    }
}
