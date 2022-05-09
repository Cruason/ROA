using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackable 
{
    public BaseDebuff StackDebuff(BaseDebuff debuffToStack, BaseDebuff newDebuff);
}
