using System;


[Serializable]
public class StatData
{
    public float hp;
    public float mana;
    public float armor;
    public float damage;
    public float attackSpeed;
    public float movementSpeed;
    
    public StatData ShallowCopy()
    {
        return (StatData) this.MemberwiseClone();
    }
}
