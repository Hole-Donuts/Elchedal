using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class StatPointData
{
    public int strength;
    public int intelligence;
    public int constitution;
    public int dexterity;
    
    public StatPointData ShallowCopy()
    {
        return (StatPointData) this.MemberwiseClone();
    }

}
