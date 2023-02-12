using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Attack", menuName = "Scriptable Objects/Character Attack")]
public class PlayerAttackTypeScriptable : ScriptableObject
{
    public int x;

    [PreviewSprite] public Sprite attackIcon;
    public List<float> attackDamage = new List<float>();
    public List<AnimationClip> animationClip = new List<AnimationClip>();
}