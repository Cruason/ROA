using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteDebuffApply : DebuffApply, IStackable
{
    public float Damage = 5f;
    public float Intensivity = 0.3f;
    public int MaxStacks = 5;

    private IgniteDebuff _igniteDebuff;


    private void Start()
    {
        _igniteDebuff = new IgniteDebuff();
        _igniteDebuff.SetDuration(this);
        _igniteDebuff.SetDamage(Damage);
        _igniteDebuff.SetIntensivity(Intensivity);
        SetDebuff(_igniteDebuff);
    }
    public BaseDebuff StackDebuff(BaseDebuff debuffToStack, BaseDebuff newDebuff)
    {
        IgniteDebuff oldDebuff = (IgniteDebuff)debuffToStack;
        IgniteDebuff debuff = (IgniteDebuff)newDebuff;
        debuff.IncrementStacks(oldDebuff.GetStacks());
        if (debuff.GetStacks() < MaxStacks)
        {
            debuff.SetDamage(oldDebuff.GetDamage() + debuff.GetDamage());
            debuff.DebuffTimeStart(Time.time);
            return debuff;
        }
        else
        {
            oldDebuff.DebuffTimeStart(Time.time);
            return oldDebuff;
        }
    }
}
