using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    
    public void MoveToTarget(Creature entity, Creature target)
    {
        if (Vector2.Distance(target.transform.position, entity.transform.position) > entity.WeaponManager._currentWeapon.AttackDistance)
        {
            entity.GoDirection = (target.transform.position - entity.transform.position).normalized;
            entity.StateMachine.SwitchState(entity.StateMachine.MoveState);
        }
        else
        {
            entity.GoDirection = Vector2.zero;
        }
    }

    public void LookToTarget(Creature entity, Vector3 target)
    {
        if (target.x - entity.transform.position.x <= 0)
        {
            entity.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            entity.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void MoveToSpawn(Creature entity, Vector3 spawn)
    {
        entity.GoDirection = (spawn - entity.transform.position).normalized;
        entity.StateMachine.SwitchState(entity.StateMachine.MoveState);
    }

    public void GoRoll(Roll roll)
    {
        roll.OnRoll();
    }

    public void GoHookShot(HookShot hookShot)
    {
        hookShot.ShotHook();
    }

    public void LookTo(Creature entity, Vector3 target)
    {
        entity.GetComponent<LookToTarget>().OnLookTo(entity, target);
    }
}
