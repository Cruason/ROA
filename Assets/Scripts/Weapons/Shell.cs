using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shell : MonoBehaviour
{
    protected float _physicalDamage;
    protected float _magicalDamage;
    protected float _speed;
    protected float _critChance;
    protected float _critMultiplier;
    protected bool _isCritUpdated;
    protected Creature _owner;

    protected BoxCollider2D _boxCollider2D;
    private void Awake()
    {
        enabled = false;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.enabled = false;
    }

    public void SetShellStats(float physicalDamage, float magicalDamage, float speed,float critChance, float critMultiplier, Creature owner)
    {
        _physicalDamage = physicalDamage;
        _magicalDamage = magicalDamage;
        _speed = speed;
        _critChance = critChance;
        _critMultiplier = critMultiplier;
        _owner = owner;
    }

    public void OnMove()
    {
        transform.Translate(0f, _speed * Time.deltaTime, 0f);
    }

    public void Enable()
    {
        enabled = true;
        _boxCollider2D.enabled = true;
    }
}
