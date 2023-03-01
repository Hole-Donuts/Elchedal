using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IDamageAble
{    
    [Header("Player Stat")] 
    public CharacterBaseData characterBaseData;
    public StatData statData;
    public StatPointData statPointData;
    public Equipment[] equipment;

    private Animator playerAnimator;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public PlayerAttackTypeScriptable playerAttackTypeScriptable;

    private const float MOVE_SPEED = 6f;

    [SerializeField] private LayerMask dashLayerMask;

    private Rigidbody2D rigidbody2D;

    private Vector3 moveDir;

    private Vector3 rollDir;
    private Vector3 lastMoveDir;
    private float rollSpeed;

    public PlayerState state;

    public float health;

    private int _attackState = 0;
    private float _attackInterval = 0.2f;
    private float _attackIntervalTimer = 0;


    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        state = PlayerState.Normal;

        statData = characterBaseData.stat.ShallowCopy();

        statPointData = characterBaseData.statPoint.ShallowCopy();
    }

    private void Update()
    {
        switch (state)
        {
            case PlayerState.Normal:
                Vector2 move = new Vector2(Input.GetAxisRaw(HORIZONTAL), Input.GetAxisRaw(VERTICAL));
                moveDir = move.normalized;

                if (move != Vector2.zero)
                {
                    // Not idle
                    lastMoveDir = moveDir;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rollDir = lastMoveDir;
                    rollSpeed = 50f;
                    state = PlayerState.Rolling;
                }
                Attacking(_attackState);

                if (Input.GetMouseButtonDown(1))
                {
                    state = PlayerState.Blocking;
                    rigidbody2D.velocity = Vector2.zero;
                }

                break;

            case PlayerState.Rolling:
                float rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 10f;
                if (rollSpeed < rollSpeedMinimum)
                {
                    state = PlayerState.Normal;
                }
                break;

            case PlayerState.Attacking:
                Attacking(_attackState);
                break;

            case PlayerState.Blocking:
                state = Input.GetMouseButtonUp(1) ? PlayerState.Normal : state;
                if (Input.GetMouseButtonUp(1))
                {
                    state = PlayerState.Normal;
                }
                break;

            case PlayerState.Delaying:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.Normal:
                rigidbody2D.velocity = moveDir * MOVE_SPEED;

                //if (isDashButtonDown)
                //{
                //    float dashAmount = 50f;
                //    Vector3 dashPosition = transform.position + lastMoveDir * dashAmount;

                //    RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, lastMoveDir, dashAmount, dashLayerMask);
                //    if (raycastHit2d.collider != null)
                //    {
                //        dashPosition = raycastHit2d.point;
                //    }

                //    // Spawn visual effect
                //    //DashEffect.CreateDashEffect(transform.position, lastMoveDir, Vector3.Distance(transform.position, dashPosition));

                //    rigidbody2D.MovePosition(dashPosition);
                //    isDashButtonDown = false;
                //}
                break;

            case PlayerState.Rolling:
                rigidbody2D.velocity = rollDir * rollSpeed;
                break;

            case PlayerState.Attacking:
                rigidbody2D.velocity = moveDir;
                break;

            case PlayerState.Delaying:
                rigidbody2D.velocity = moveDir;
                break;
        }
    }

    public void Attacking(int attackState)
    {
        if (Input.GetMouseButtonDown(0))
        {
            state = PlayerState.Delaying;
            if (_attackState == playerAttackTypeScriptable.moveSets.Count)
            {
                _attackState = 0;
            }
            StopAllCoroutines();
            StartCoroutine(Attack(_attackState));
        }
    }

    private IEnumerator Attack(int attackState)
    {
        moveDir = Vector2.zero;
        playerAnimator.CrossFade(playerAttackTypeScriptable.moveSets[attackState].animationClip.name, 0);
        float time = playerAnimator.runtimeAnimatorController.animationClips.First(x => x.name == playerAttackTypeScriptable.moveSets[attackState].animationClip.name).length;
        yield return new WaitForSeconds(time - _attackInterval);
        state = PlayerState.Attacking;
        _attackState += 1;
        _attackIntervalTimer = _attackInterval;
        yield return new WaitForSeconds(_attackInterval);
        _attackState = 0;
        state = PlayerState.Normal;
    }

    public void Damaged(float _damage)
    {
        switch (state)
        {
            case PlayerState.Normal:
                health -= _damage;
                break;

            case PlayerState.Rolling:
                break;

            case PlayerState.Attacking:
                health -= _damage;
                break;
        }
    }

    [ContextMenu("Calculate stat data")]
    public void CalculateStatData()
    {
        statData.hp = characterBaseData.stat.hp + (statPointData.constitution * 5) + equipment[(int)EquipmentType.Armor].hp;
        statData.armor=characterBaseData.stat.armor+(statPointData.constitution * 2)+equipment[(int)EquipmentType.Armor].armor;
        statData.damage = characterBaseData.stat.damage + (statPointData.strength * 2) + equipment[(int)EquipmentType.Weapon].damage;
    }
}