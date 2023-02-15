using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public const string ENEMY = "Enemy";
    public PlayerSkill playerSkill1;
    public PlayerSkill playerSkill2;
    public PlayerSkill playerSkill3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageAble enemyDamageAble = (collision.gameObject.CompareTag(ENEMY)) ? collision.gameObject.GetComponent<IDamageAble>() : null;
        if (enemyDamageAble != null)
        {
            enemyDamageAble.Damaged(100);
        }
    }
}