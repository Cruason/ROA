using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{

    public Animator Animator;
    public Creature Owner;
    public float PhysicalDamage = 2;
    public float MagicalDamage = 2;
    public float AttackDistance;
    public float DontAttackDistance=1f;

    protected float _physicalDamage;
    protected float _magicalDamage;
    protected float _critChance = 50f;
    protected float _critMultiplier = 150f;

    public void SetOwner(Creature owner)
    {
        Owner = owner;
        Amplify();
    }

    public virtual void Use() { }

    public void SetDamage(float physicalDamage, float magicalDamage)
    {
        _physicalDamage = physicalDamage;
        _magicalDamage = magicalDamage;
    }

    public abstract void Amplify();
}
