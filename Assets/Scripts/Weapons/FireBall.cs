using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Shell, IDamagable
{
    private float _offSet = 10f;
    private float _explodeArea;
    private float _lastDamage;
    private float _burnIntensivity;
    private float _explodeDuration;
    private float _lastExplode;
    private bool _explode;

    private void FixedUpdate()
    {
        OnMove();
        if (Vector2.Distance(_owner.transform.position, transform.position) > _offSet)
        {
            Destroy(gameObject);
        }
        if (_explode)
        {
            if (Time.time - _lastDamage > _burnIntensivity)
            {
                _boxCollider2D.enabled = true;
                _lastDamage = Time.time;
            }
            else
            {
                _boxCollider2D.enabled = false;
            }
            if (Time.time - _lastExplode >= _explodeDuration)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Creature _))
        {
            var target = collision.GetComponent<Creature>();
            if (target.GetType() != _owner.GetType())
            {
                if (!_explode)
                {
                    Explode();
                }
            }
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
        if(damage.IsCrit)
        {
            damage.DamageAmountPhysical *= _critMultiplier / 100f;
            damage.DamageAmountMagical *= _critMultiplier / 100f;
        }
        return damage;
    }

    private void Explode()
    {
        _speed = 0f;
        transform.localScale *= _explodeArea;
        _explode = true;
        _lastExplode = Time.time;
    }

    public void SetModifications(float explodeArea, float burnIntensivity, float explodeDuration)
    {
        _explodeArea = explodeArea;
        _burnIntensivity = burnIntensivity;
        _explodeDuration = explodeDuration;
    }
}
