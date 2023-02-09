using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace x
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IDamageAble
    {
        private Animator playerAnimator;
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        public PlayerAttack playerAttack;

        private const float MOVE_SPEED = 6f;

        public enum State
        {
            Normal,
            Rolling,
            Attacking,
            Blocking,
            Delaying
        }

        [SerializeField] private LayerMask dashLayerMask;

        private Rigidbody2D rigidbody2D;

        private Vector3 moveDir;

        private Vector3 rollDir;
        private Vector3 lastMoveDir;
        private float rollSpeed;

        public State state;

        public float health;

        private int _attackState = 0;
        private float _attackInterval = 0.2f;
        private float _attackIntervalTimer = 0;

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            state = State.Normal;
        }

        private void Update()
        {
            switch (state)
            {
                case State.Normal:
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
                        state = State.Rolling;
                    }
                    Attacking(_attackState);

                    if (Input.GetMouseButtonDown(1))
                    {
                        state = State.Blocking;
                        rigidbody2D.velocity = Vector2.zero;
                    }

                    break;

                case State.Rolling:
                    float rollSpeedDropMultiplier = 5f;
                    rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                    float rollSpeedMinimum = 10f;
                    if (rollSpeed < rollSpeedMinimum)
                    {
                        state = State.Normal;
                    }
                    break;

                case State.Attacking:
                    Attacking(_attackState);
                    break;

                case State.Blocking:
                    state = Input.GetMouseButtonUp(1) ? State.Normal : state;
                    if (Input.GetMouseButtonUp(1))
                    {
                        state = State.Normal;
                    }
                    break;

                case State.Delaying:
                    break;
            }
        }

        private void FixedUpdate()
        {
            switch (state)
            {
                case State.Normal:
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

                case State.Rolling:
                    rigidbody2D.velocity = rollDir * rollSpeed;
                    break;

                case State.Attacking:
                    rigidbody2D.velocity = moveDir;
                    break;
            }
        }

        public void Attacking(int attackState)
        {
            //if (_attackIntervalTimer > 0)
            //{
            //    _attackIntervalTimer -= Time.deltaTime;
            //}
            if (Input.GetMouseButtonDown(0))
            {
                state = State.Delaying;
                if (_attackState == playerAttack.animationClip.Count)
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
            playerAnimator.CrossFade(playerAttack.animationClip[attackState].name, 0);
            float time = playerAnimator.runtimeAnimatorController.animationClips.First(x => x.name == playerAttack.animationClip[attackState].name).length;
            yield return new WaitForSeconds(time - _attackInterval);
            state = State.Attacking;
            _attackState += 1;
            _attackIntervalTimer = _attackInterval;
            yield return new WaitForSeconds(_attackInterval);
            //if (attackState != _attackState)
            //{
            //    Debug.Log("Kebreak");
            //    yield break;
            //}
            _attackState = 0;
            state = State.Normal;
        }

        public void Damaged(float _damage)
        {
            switch (state)
            {
                case State.Normal:
                    health -= _damage;
                    break;

                case State.Rolling:
                    break;

                case State.Attacking:
                    health -= _damage;
                    break;
            }
        }
    }
}