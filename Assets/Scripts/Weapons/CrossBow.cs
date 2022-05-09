using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : WeaponBase
{
    public GameObject Arrow;

    public float ArrowSpeed = 1f;
    public float FireRate = 1f;

    private float _fireRate;
    private float _lastFire;

    private GameObject _currentArrow;

    private void Start()
    {
        SetFireRate(FireRate);
    }
    private void Update()
    {
        CreateArrow();
    }

    public void SetFireRate(float fireRate)
    {
        _fireRate = fireRate;
    }

    private void CreateArrow()
    {
        if(TryToCreate())
        {
            _currentArrow = Instantiate(Arrow, transform);
            var shell = _currentArrow.GetComponent<Arrow>();
            shell.SetShellStats(_physicalDamage, _magicalDamage, ArrowSpeed, _critChance, _critMultiplier, Owner);
        }
    }

    private bool TryToCreate()
    {
        if(transform.childCount!=0)
        {
            return false;
        }
        if(Time.time - _lastFire < _fireRate)
        {
            return false;
        }

        return true;
    }

    public override void Use()
    {
        if (Time.time - _lastFire < _fireRate)
        {
            return;
        }
        if (transform.childCount == 0)
        {
            return;
        }
        _lastFire = Time.time;
        Animator.SetTrigger("Shot");
        _currentArrow.transform.SetParent(null);
        _currentArrow.GetComponent<Shell>().Enable();
    }

    public override void Amplify()
    {
        var Empower = Owner.GetComponent<Empower>();
        SetDamage(PhysicalDamage * Empower.GetEmpowers(WeaponType.range), MagicalDamage * Empower.GetEmpowers(WeaponType.magic));
    }
}
