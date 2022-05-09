using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : WeaponBase
{
    public GameObject FireBall;

    public float BallSpeed = 1f;
    public float FireRate = 1f;
    public float ExplodeArea = 2f;
    public float BurnIntensivity = 1f;
    public float ExplodeDuration = 3f;

    private float _fireRate;
    private float _lastFire;

    private GameObject _currentFireBall;

    private void Start()
    {
        SetFireRate(FireRate);
    }
    private void Update()
    {
        CreateFireBall();
    }

    public void SetFireRate(float fireRate)
    {
        _fireRate = fireRate;
    }

    private void CreateFireBall()
    {
        if (TryToCreate())
        {
            _currentFireBall = Instantiate(FireBall, transform);
            var shell = _currentFireBall.GetComponent<FireBall>();
            shell.SetShellStats(_physicalDamage, _magicalDamage, BallSpeed, _critChance, _critMultiplier, Owner);
            shell.SetModifications(ExplodeArea, BurnIntensivity, ExplodeDuration);
        }
    }

    private bool TryToCreate()
    {
        if (transform.childCount != 0)
        {
            return false;
        }
        if (Time.time - _lastFire < _fireRate)
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
        if(transform.childCount == 0)
        {
            return;
        }
        _lastFire = Time.time;
        Animator.SetTrigger("Shot");
        _currentFireBall.transform.SetParent(null);
        _currentFireBall.GetComponent<Shell>().Enable();
    }

    public override void Amplify()
    {
        var Empower = Owner.GetComponent<Empower>();
        SetDamage(PhysicalDamage * Empower.GetEmpowers(WeaponType.range), MagicalDamage * Empower.GetEmpowers(WeaponType.magic));
    }
}
