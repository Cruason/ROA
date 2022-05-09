using UnityEngine;

public abstract class Empower : MonoBehaviour
{
    public abstract void SetEmpowers();

    public abstract float GetEmpowers(WeaponType weaponType);
}
