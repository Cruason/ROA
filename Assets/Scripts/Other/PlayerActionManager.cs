using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionManager : ActionManager
{
    private InputService _readInputs;
    private Player _player;
    private Roll _playerRoll;
    private HookShot _playerHookShot;
    private RotateToTarget _rotateToTarget;

    private void Awake()
    {
        _readInputs = InputService.Instance.GetComponent<InputService>();
    }
    private void OnEnable()
    {
        _readInputs.RollPress += PlayerOnRoll;
        _readInputs.HookPress += PlayerShotHook;
        _readInputs.RightMouseClick += OnLookToMouse;
    }

    private void OnDisable()
    {
        _readInputs.RollPress -= PlayerOnRoll;
        _readInputs.HookPress -= PlayerShotHook;
        _readInputs.RightMouseClick -= OnLookToMouse;
    }
    void Start()
    {
        FindPlayerType();
        
    }

    void Update()
    {
        _player.RotateToTarget.Rotate(_player,Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FindPlayerType()
    {
        _player = FindObjectOfType<Player>();
        _playerRoll = _player.GetComponent<Roll>();
        _playerHookShot = _player.GetComponentInChildren<HookShot>();
    }
    private void PlayerOnRoll()
    {
        GoRoll(_playerRoll);
    }

    private void PlayerShotHook()
    {
        GoHookShot(_playerHookShot);
    }

    private void OnLookToMouse()
    {
        LookTo(_player, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
