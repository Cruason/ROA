using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDebuff
{
    protected float _duration = 3f;
    protected float _lastDebuffTime;

    public virtual void SetDuration(DebuffApply debuffApply)
    {
        _duration = debuffApply.Duration;
    }

    public void DebuffTimeStart(float time)
    {
        _lastDebuffTime = time;
    }

    public abstract void StartDebuff(Creature target);

    public abstract bool OnDebaff(Creature target);

    public abstract void EndDebuff(Creature target);

    public abstract BaseDebuff DebuffInstance();
}
