using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    private PlayerController playerController;
    private int _attackState = 0;
    private PlayerAttackTypeScriptable playerAttackTypeScriptable;
    public PlayerAttackTypeScriptable playerAttackTypeScriptableSetter
    {
        set
        {
            playerAttackTypeScriptable = value;
        }
    }

    public IEnumerator a;

    public void Attacking(ref PlayerState playerState)
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerState = PlayerState.Delaying;
            if (_attackState == playerAttackTypeScriptable.animationClip.Count)
            {
                _attackState = 0;
            }
            //playerController.StopCoroutine(Attack(_attackState));
            //playerController.StartCoroutine(Attack(_attackState));
        }
    }

    //private IEnumerator Attack(int attackState)
    //{
    //    moveDir = Vector2.zero;
    //    playerAnimator.CrossFade(playerAttackTypeScriptable.animationClip[attackState].name, 0);
    //    float time = playerAnimator.runtimeAnimatorController.animationClips.First(x => x.name == playerAttackTypeScriptable.animationClip[attackState].name).length;
    //    yield return new WaitForSeconds(time - _attackInterval);
    //    state = PlayerState.Attacking;
    //    _attackState += 1;
    //    _attackIntervalTimer = _attackInterval;
    //    yield return new WaitForSeconds(_attackInterval);
    //    _attackState = 0;
    //    state = PlayerState.Normal;
    //}
}