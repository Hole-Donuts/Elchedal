using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] protected StatSCharacter _StatusCharacter;


    private float _HealthPoint;
    [SerializeField] float _MaxHealthPoint;

    [Header("Variable to Move")]
    [SerializeField] protected private Transform _Target;
    private SpriteRenderer _SP;
    protected private Animator _animator;

    [Header("Variable to Attack")]
    [SerializeField] BoxCollider2D _Collider;
    protected private float _CooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {

        _HealthPoint = _MaxHealthPoint;
        _Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _SP = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInArea())
        {
            Move();
        }
        else
        {
            MoveStop();
        }

        TurnDirection();
        Attack();
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, _Target.position) < _StatusCharacter._Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _Target.position, _StatusCharacter._Speed * Time.deltaTime);
            _animator.SetBool("Move", true);
        }

    }

    protected virtual void MoveStop()
    {
        _animator.SetBool("Move", false);
    }


    protected virtual void TurnDirection()
    {
        if (transform.position.x < _Target.position.x)
        {
            _SP.flipX = true;
        }
        else
        {
            _SP.flipX = false;
        }
    }

    protected virtual void Attack()
    {
        _CooldownTimer += Time.deltaTime;
        if (PlayerInArea())
        {
            if (_CooldownTimer >= _StatusCharacter._AttackCooldown)
            {
                _CooldownTimer = 0;
                _animator.SetTrigger("Attack");
            }
        }
    }

    protected virtual bool PlayerInArea()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_Collider.bounds.center, _Collider.bounds.size, 0, Vector2.zero, 0, _StatusCharacter._LayerMask);
        return hit.collider != null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_Collider.bounds.center, _Collider.bounds.size);
    }

}
