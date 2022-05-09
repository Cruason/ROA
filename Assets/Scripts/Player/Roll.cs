using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float RollCD = 3f;
    public float Speed = 10f;

    private float lastRoll;
    private StateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
    }
 
    public void OnRoll()
    {
        if (Time.time - lastRoll > RollCD)
        {
            _stateMachine.SwitchState(_stateMachine.RollState);
            if(_stateMachine.CurrentState == _stateMachine.RollState)
            {
            lastRoll = Time.time;
            }
        }
    }
}
