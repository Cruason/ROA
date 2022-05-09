using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteDebuff : BaseDebuff
{
    private float _damage;
    private float _intensivity;
    private float _lastBurn;
    private float _stacks=0;

    private AllStats targetHp;

    public void SetDamage(float damage)
    {
        Debug.Log(_stacks);
        _damage = damage;
    }

    public void SetIntensivity(float intensivity)
    {
        _intensivity = intensivity;
    }
    
    public void IncrementStacks(float currentStacks)
    {
        _stacks = currentStacks;
        _stacks++;
    }

    public float GetStacks()
    {
        return _stacks;
    }

    public float GetDamage()
    {
        return _damage;
    }

    public override void StartDebuff(Creature target)
    {
        _lastDebuffTime = Time.time;
        _lastBurn = Time.time;
        targetHp = target.GetComponent<AllStats>();
    }

    public override bool OnDebaff(Creature target)
    {
        if (Time.time - _lastDebuffTime > _duration)
        {
            return false;
        }
        if(Time.time - _lastBurn > _intensivity)
        {
            targetHp.Hp -= _damage;
            FloatingTextManager.Instance.ShowText("-" + _damage, 20, Color.yellow, target.transform.position, Vector2.up * 50f, 2f);
            _lastBurn = Time.time;
        }
        return true;
    }

    public override void EndDebuff(Creature target)
    {
    }

    public override BaseDebuff DebuffInstance()
    {
        IgniteDebuff clone = (IgniteDebuff)this.MemberwiseClone();
        return clone;
    }
}
