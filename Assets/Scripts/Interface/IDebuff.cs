using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDebuff
{
    public void SetDebuff(BaseDebuff debuff);
    public BaseDebuff GetDebuff();
}
