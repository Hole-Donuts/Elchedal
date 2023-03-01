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
            if (_attackState == playerAttackTypeScriptable.moveSets.Count)
            {
                _attackState = 0;
            }
        }
    }


}