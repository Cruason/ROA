using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Shell
{
    private float _targetSpeed = 10f;
    private bool _hooked;
    private StateMachine _stateMachine;
    private Movement _movement;
    private float _offSet = 10f;
    private void Start()
    {
        _stateMachine = _owner.GetComponent<StateMachine>();
        _movement = _owner.GetComponent<Movement>();
        _movement.SetSpeed(0f);
        
    }
    private void FixedUpdate()
    {
        OnMove();
        if(Vector2.Distance(_owner.transform.position, transform.position) > _offSet)
        {
            StopHook();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollide(collision);
    }
    private void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Interactable"))
        {
            _speed = 0f;
            Hooked();
            _hooked = true;
        }
        if(_hooked)
        {
            if (collider.TryGetComponent(out Creature _))
            {
                var target = collider.GetComponent<Creature>();
                if (target.GetType() == _owner.GetType())
                {
                    StopHook();
                }
            }
        }
    }

    private void Hooked()
    {
        _movement.SetSpeed(_targetSpeed);
        _stateMachine.HookState.SetDirection((transform.position - _owner.transform.position).normalized);
    }

    private void StopHook()
    {
        var _movement = _owner.GetComponent<Movement>();
        _movement.DefaultSpeed();
        _stateMachine.SwitchState(_stateMachine.IdleState);
        Destroy(gameObject);
    }
}
