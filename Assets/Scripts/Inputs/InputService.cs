using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private float _horizontal;
    [SerializeField] private float _vertical;

    public event Action LeftMouseClick;
    public event Action RightMouseClick;
    public event Action ChangeWeaponPress;
    public event Action RollPress;
    public event Action HookPress;
    public event Action WeaponModificationPress;

    public float Horizontal => _horizontal;
    public float Vertical => _vertical;

    public static InputService Instance { get => GetInstance(); }

    private static InputService _instance;

    private void Update()
    {
        FillAxes();
        FillMouseInputs();
        FillButtonInputs();
    }

    private static InputService GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<InputService>();
        }
        return _instance;
    }
    private void FillAxes()
    {
        _horizontal = Input.GetAxis(InputAxis.Horizontal);
        _vertical = Input.GetAxis(InputAxis.Vertical);
    }

    private void FillMouseInputs()
    {
        if (Input.GetMouseButtonDown((int)ReadMouseClick.LeftButton))
        {
            LeftMouseClick?.Invoke();
        }
        if (Input.GetMouseButtonDown((int)ReadMouseClick.RightButton))
        {
            RightMouseClick?.Invoke();
        }
    }

    private void FillButtonInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeaponPress?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RollPress?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            HookPress?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            WeaponModificationPress?.Invoke();
        }
    }
}
