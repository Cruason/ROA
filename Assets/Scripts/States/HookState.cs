using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookState : BaseState
{
    private Vector2 _direction;
    private Movement _move;
    public override void EnterState(StateMachine entity)
    {
        _move = entity.GetComponent<Movement>();
        NextStates.Add(entity.IdleState);
    }

    public override void OnState(StateMachine entity)
    {
        _move.MoveMotor(_direction.x, 0);
        _move.MoveThroughCliff();
        _move.MoveMotor(0, _direction.y);
        _move.MoveThroughCliff();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
