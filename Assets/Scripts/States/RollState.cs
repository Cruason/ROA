using UnityEngine;

public class RollState : BaseState
{
    private Vector2 _direction;
    private Roll _roll;
    private Creature _creature;
    private Movement _move;
    private float _duration = 0.5f;
    private float _lastRoll;
    public override void EnterState(StateMachine entity)
    {
        Debug.Log("rollState");
        _creature = entity.GetCreature();
        NextStates.Add(entity.IdleState);
        _move = entity.GetComponent<Movement>();
        _roll = entity.GetComponent<Roll>();
        _move.SetSpeed(_roll.Speed);
        _lastRoll = Time.time;
        entity.LockState = true;

        if (_creature.GoDirection == Vector2.zero)
        {
            _direction = new Vector2(_creature.transform.localScale.x, 0);
        }
        else
        {
            _direction = _creature.GoDirection.normalized;
        }
    }

    public override void OnState(StateMachine entity)
    {

        _move.MoveMotor(_direction.x, 0);
        _move.MoveMotor(0, _direction.y);
        if (Time.time - _lastRoll > _duration)
        {
            StopRoll(entity);
        }
    }

    private void StopRoll(StateMachine entity)
    {
        _move.DefaultSpeed();
        entity.LockState = false;
        entity.SwitchState(entity.IdleState);
    }
}
