using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebuffApply : MonoBehaviour , IDebuff
{
    protected BaseDebuff _debuff;

    public float Duration=3f;
    public void SetDebuff(BaseDebuff debuff)
    {
        _debuff = debuff;
    }

    public BaseDebuff GetDebuff()
    {
        return _debuff;
    }    
}
