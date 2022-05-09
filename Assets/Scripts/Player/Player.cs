using System;
using UnityEngine;

[RequireComponent(typeof(StateMachine), typeof(UpdateHpAndMAna), typeof(Movement))]
public class Player : Creature
{
    private InputService _readInputs;
    
    private void Awake()
    {
        _readInputs = InputService.Instance.GetComponent<InputService>();
    }

    private void Start()
    {
        RotateToTarget = GetComponentInChildren<RotateToTarget>();
    }

    private void Update()
    {
        GoDirection.Set(_readInputs.Horizontal, _readInputs.Vertical);
    }

}
