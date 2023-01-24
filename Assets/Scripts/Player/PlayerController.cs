using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace x
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IDamageAble
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        private const string DODGE = "Jump";

        //    private Rigidbody2D rb2D;

        //    [SerializeField]
        //    private float speed;

        //    private float health;

        //    private void Awake()
        //    {
        //        rb2D = GetComponent<Rigidbody2D>();
        //    }

        //    private void Update()
        //    {
        //        Vector2 move = new Vector2(Input.GetAxisRaw(HORIZONTAL), Input.GetAxisRaw(VERTICAL));
        //        move = move.normalized * Time.fixedDeltaTime * speed;
        //        Moving(move);
        //    }

        //    public void Moving(Vector2 _move)
        //    {
        //        rb2D.velocity = _move;
        //        if (Input.GetButtonDown(DODGE))
        //            rb2D.velocity *= 100;
        //    }

        private const float MOVE_SPEED = 6f;

        private enum State
        {
            Normal,
            Rolling,
            Attacking
        }

        [SerializeField] private LayerMask dashLayerMask;

        private Rigidbody2D rigidbody2D;

        //private Vector3 moveDir;
        private Vector3 moveDir;

        private Vector3 rollDir;
        private Vector3 lastMoveDir;
        private float rollSpeed;

        //private bool isDashButtonDown;
        private State state;

        public float health;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            state = State.Normal;
        }

        private void Update()
        {
            switch (state)
            {
                case State.Normal:
                    Vector2 move = new Vector2(Input.GetAxisRaw(HORIZONTAL), Input.GetAxisRaw(VERTICAL));
                    //float moveX = 0f;
                    //float moveY = 0f;

                    //if (Input.GetKey(KeyCode.W))
                    //{
                    //    moveY = +1f;
                    //}
                    //if (Input.GetKey(KeyCode.S))
                    //{
                    //    moveY = -1f;
                    //}
                    //if (Input.GetKey(KeyCode.A))
                    //{
                    //    moveX = -1f;
                    //}
                    //if (Input.GetKey(KeyCode.D))
                    //{
                    //    moveX = +1f;
                    //}

                    //moveDir = new Vector3(moveX, moveY).normalized;
                    moveDir = move.normalized;

                    //if (moveX != 0 || moveY != 0)
                    //{
                    //    // Not idle
                    //    lastMoveDir = moveDir;
                    //}
                    if (move != Vector2.zero)
                    {
                        // Not idle
                        lastMoveDir = moveDir;
                    }
                    //characterBase.PlayMoveAnim(moveDir);

                    //if (Input.GetKeyDown(KeyCode.F))
                    //{
                    //    isDashButtonDown = true;
                    //}

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        rollDir = lastMoveDir;
                        rollSpeed = 50f;
                        state = State.Rolling;
                        //characterBase.PlayRollAnimation(rollDir);
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        state = State.Attacking;
                        StartCoroutine(Attack());
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

        private IEnumerator Attack()
        {
            moveDir = Vector2.zero;
            Debug.Log("Mulai Attack");
            yield return new WaitForSeconds(2f);
            Debug.Log("Selesai Attack");
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
                    break;
            }
        }
    }
}