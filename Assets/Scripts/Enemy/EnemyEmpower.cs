using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmpower : Empower
{
    public Dictionary<WeaponType, float> Empowers = new Dictionary<WeaponType, float>()
    {
        { WeaponType.melee, 100f },
        { WeaponType.range, 100f },
        { WeaponType.magic, 100f }
    };

    private AllStats AllStats;

    private void Start()
    {
        AllStats = GetComponent<AllStats>();
        SetEmpowers();
    }

    public override void SetEmpowers()
    {
        Empowers[WeaponType.melee] = AllStats.MeleePower;
        Empowers[WeaponType.range] = AllStats.RangePower;
        Empowers[WeaponType.magic] = AllStats.MagicPower;
    }

    public override float GetEmpowers(WeaponType weaponType)
    {
        return Empowers[weaponType];
    }
}
