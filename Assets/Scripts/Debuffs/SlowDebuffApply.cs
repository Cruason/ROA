using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuffApply : DebuffApply
{
    public float SlowingRate=50f;

    private MoveSpeedDebuff _moveSpeedDebuff;

    private void Start()
    {
        _moveSpeedDebuff = new MoveSpeedDebuff();
        _moveSpeedDebuff.SetDuration(this);
        _moveSpeedDebuff.SetSlowingRate(SlowingRate);
        SetDebuff(_moveSpeedDebuff);
    }
}
