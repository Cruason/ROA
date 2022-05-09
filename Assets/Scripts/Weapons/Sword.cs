using UnityEngine;

public class Sword : WeaponBase, IDamagable
{
    private float _pushForceUpdated;
    private bool _isCritUpdated;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public override void Use()
    {
        Animator.SetTrigger("Swing");
    }


    public Damage GetDamage()
    {
        if (Random.Range(0, 100) <= _critChance)
        {
            _isCritUpdated = true;
        }
        else
        {
            _isCritUpdated = false;
        }

        Damage damage = new Damage()
        {
            DamageAmountPhysical = _physicalDamage,
            DamageAmountMagical = _magicalDamage,
            PushForce = _pushForceUpdated,
            Owner = Owner,
            IsCrit = _isCritUpdated,
        };
        if (damage.IsCrit)
        {
            damage.DamageAmountPhysical *= _critMultiplier / 100f;
            damage.DamageAmountMagical *= _critMultiplier / 100f;
        }
        return damage;
    }

    public override void Amplify()
    {
        var Empower = Owner.GetComponent<Empower>();
        SetDamage(PhysicalDamage * Empower.GetEmpowers(WeaponType.melee), MagicalDamage * Empower.GetEmpowers(WeaponType.magic));
    }

}
