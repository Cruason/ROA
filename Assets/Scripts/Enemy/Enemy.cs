using UnityEngine;
[RequireComponent(typeof(StateMachine), typeof(UpdateHpAndMAna), typeof(Movement))]

public class Enemy : Creature
{
    public float ChaseDistance=5f;
    public float TriggerDistance = 5f;

    public bool Chase;
    public Vector3 SpawnPosition;

    private void Start()
    {
        RotateToTarget = GetComponentInChildren<RotateToTarget>();
        StateMachine = GetComponent<StateMachine>();
        SpawnPosition = transform.position;
        WeaponManager = GetComponent<WeaponEnemyManager>();
    }
    private void Update()
    {

    }

    public void Attack()
    {
        WeaponManager._currentWeapon.Use();
    }

}
