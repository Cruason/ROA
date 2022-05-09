using UnityEngine;

public class IdleState : BaseState
{
    private Creature _creature;
    public override void EnterState(StateMachine entity)
    {
        Debug.Log("Idle State");
        _creature = entity.GetCreature();

        NextStates.Add(entity.MoveState);
        NextStates.Add(entity.RollState);
        NextStates.Add(entity.HookState);
    }

    public override void OnState(StateMachine entity)
    {
        if(_creature.GoDirection != Vector2.zero)
        {
            entity.SwitchState(entity.MoveState);
        }
    }
}
