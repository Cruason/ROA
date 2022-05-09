using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponBase> _weapons = new List<WeaponBase>();

    public WeaponBase _currentWeapon;
    public WeaponBase _previousWeapon;

    public GameObject BackPack;
    public GameObject WeaponSlot;

    private WeaponBase[] _allWeapons;
    private int index = 0;
    private Creature _owner;
    private void Start()
    {
        InitWeapons();
        SetWeaponOwner();
        _currentWeapon = _weapons[index];
        _currentWeapon.enabled = true;
    }
    public void OnUseWeapon()
    {
        _currentWeapon.Use();
    }

    public void InitWeapons()
    {
        _allWeapons = GetComponentsInChildren<WeaponBase>();
        for(int i=0;i<_allWeapons.Length;i++)
        {
            _weapons.Add(_allWeapons[i]);
        }
    }

    public void SetWeaponOwner()
    {
        _owner = GetComponent<Creature>();
        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].SetOwner(_owner);
        }
    }

    public void SwitchWeapon()
    {
        _previousWeapon = _currentWeapon;
        index++;
        if (index == _weapons.Count)
        {
            index = 0;
        }
        _currentWeapon = _weapons[index];
        PutInBackPack(_previousWeapon);
        PutInWeaponSlot(_currentWeapon);
        _currentWeapon.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    public void PutInBackPack(WeaponBase weapon)
    {
        weapon.transform.SetParent(BackPack.transform);
        weapon.transform.localEulerAngles = Vector3.zero;
        weapon.transform.localPosition = Vector3.zero;
        weapon.enabled = false;
    }

    public void PutInWeaponSlot(WeaponBase weapon)
    {
        weapon.transform.SetParent(WeaponSlot.transform);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localScale = Vector3.one;
        weapon.enabled = true;
    }
}
