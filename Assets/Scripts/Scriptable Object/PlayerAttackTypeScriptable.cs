using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Attack", menuName = "Scriptable Objects/Character Attack")]
public class PlayerAttackTypeScriptable : ScriptableObject
{
    [PreviewSprite] public Sprite attackIcon;
    public List<MoveData> moveSets;
}