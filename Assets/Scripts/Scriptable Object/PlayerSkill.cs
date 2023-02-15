using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Skill", menuName = "Scriptable Objects/Character Skill")]
public class PlayerSkill : ScriptableObject
{
    public string skillName;
    public float skillDamage;
    [PreviewSprite] public Sprite skillIcon;
    public AnimationClip animationClip;
}