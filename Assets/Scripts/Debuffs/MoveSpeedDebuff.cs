using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedDebuff : BaseDebuff
{
    private float _slowingRate = 50f;

    private float _targetSpeed;
    private float _speedReduced;

    public override void SetDuration(DebuffApply debuffApply)
    {
        base.SetDuration(debuffApply);
        SetSlowingRate(_slowingRate);
    }

    public void SetSlowingRate(float slowingRate)
    {
        _slowingRate = slowingRate;
    }

    public override void StartDebuff(Creature target)
    {
        _targetSpeed = target.GetComponent<AllStats>().Speed;
        _speedReduced = _targetSpeed * _slowingRate / 100;
        target.GetComponent<AllStats>().Speed -= _speedReduced;
        _lastDebuffTime = Time.time;
    }

    public override bool OnDebaff(Creature target)
    {
        if(Time.time- _lastDebuffTime > _duration)
        {
            return false;
        }
        return true;
    }

    public override void EndDebuff(Creature target)
    {
        target.GetComponent<AllStats>().Speed += _speedReduced;
    }

    public override BaseDebuff DebuffInstance()
    {
        MoveSpeedDebuff clone = (MoveSpeedDebuff)this.MemberwiseClone();
        return clone;
    }
}
