using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    public float HookCD = 3f;
    public GameObject Hook;
    private GameObject _currentHook;
    private Creature _owner;
    private StateMachine _stateMachine;
    private float _hookSpeed = 10f;
    private float lastHook;
    
    private void Start()
    {
        _owner = transform.parent.GetComponent<Creature>();
        _stateMachine = _owner.GetComponent<StateMachine>();
    }

    public void ShotHook()
    {
        if(Time.time - lastHook > HookCD)
        {
            _stateMachine.SwitchState(_stateMachine.HookState);
            if(_stateMachine.CurrentState == _stateMachine.HookState)
            {
                _currentHook = Instantiate(Hook, transform);
                _currentHook.GetComponent<Shell>().SetShellStats(0, 0, _hookSpeed, 0, 0, _owner);
                _currentHook.GetComponent<Shell>().Enable();
                _currentHook.transform.SetParent(null);
                lastHook = Time.time;
            }
        }
    }
}
