using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Shell, IDamagable
{
    private float _offSet = 10f;
    private void FixedUpdate()
    {
        OnMove();
        if (Vector2.Distance(_owner.transform.position, transform.position) > _offSet)
        {
            Destroy(gameObject);
        }
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
            PushForce = 0f,
            Owner = _owner,
            IsCrit = _isCritUpdated,
        };
        if (damage.IsCrit)
        {
            damage.DamageAmountPhysical *= _critMultiplier / 100f;
            damage.DamageAmountMagical *= _critMultiplier / 100f;
        }
        return damage;
    }
}
