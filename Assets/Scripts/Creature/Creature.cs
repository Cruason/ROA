using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public Vector2 GoDirection;

    public bool LookRight;
    //public float AttackDistance = 1f;
    //public float DontAttackDistance = 1f;

    public StateMachine StateMachine;
    public RotateToTarget RotateToTarget;
    public WeaponManager WeaponManager;
    
}
