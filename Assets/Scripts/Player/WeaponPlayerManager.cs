using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayerManager : WeaponManager
{
    private InputService _readInputs;
    
    private void Awake()
    {
        _readInputs = InputService.Instance.GetComponent<InputService>();
    }

    private void OnEnable()
    {
        _readInputs.LeftMouseClick += OnUseWeapon;
        _readInputs.ChangeWeaponPress += SwitchWeapon;
    }

    private void OnDisable()
    {
        _readInputs.LeftMouseClick -= OnUseWeapon;
        _readInputs.ChangeWeaponPress -= SwitchWeapon;
    }
}
