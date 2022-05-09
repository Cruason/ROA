using UnityEngine;

public class MoveState : BaseState
{
    private Vector2 _direction;
    private Movement _move;
    private Creature _creature;
    
    public override void EnterState(StateMachine entity)
    {
        Debug.Log("Move State");
        _move = entity.GetComponent<Movement>();
        _creature = entity.GetCreature();

        NextStates.Add(entity.IdleState);
        NextStates.Add(entity.RollState);
        NextStates.Add(entity.HookState);
    }

    public override void OnState(StateMachine entity)
    {
        _direction = _creature.GoDirection;
        _move.MoveMotor(_direction.x, 0);
        _move.MoveMotor(0, _direction.y);
        if (_creature.GoDirection == Vector2.zero)
        {
            entity.SwitchState(entity.IdleState);
        }
        if (_move.MoveRight != _creature.LookRight && _direction.x != 0)
        {
            _move.SetSpeed(_move.GetDefaultSpeed() / 2);
        }
        else
        {
            _move.DefaultSpeed();
        }
    }
}
