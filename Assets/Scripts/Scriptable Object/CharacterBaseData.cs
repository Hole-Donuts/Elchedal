using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Objects/Character Data")]
public class CharacterBaseData : ScriptableObject
{

    public string name;
    public StatData stat;
    public StatPointData statPoint;
}
