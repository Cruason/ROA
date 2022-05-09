using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState CurrentState;
    public BaseState PrevioutsState;
    public IdleState IdleState = new IdleState();
    public MoveState MoveState = new MoveState();
    public RollState RollState = new RollState();
    public HookState HookState = new HookState();

    public bool LockState;
    public void Start()
    {
        CurrentState = IdleState;
        CurrentState.EnterState(this);
    }

    public void Update()
    {
        CurrentState.OnState(this);
    }

    public void SwitchState(BaseState state)
    {
        if(!TryToSwitchState(state, CurrentState))
        {
            return;
        }
        PrevioutsState = CurrentState;
        CurrentState = state;
        CurrentState.EnterState(this);
    }

    private bool TryToSwitchState(BaseState switchingState, BaseState currentState)
    {
        if (CurrentState == switchingState)
        {
            return false;
        }
        if(currentState.NextStates == null)
        {
            return false;
        }
        if (!currentState.NextStates.Contains(switchingState))
        {
            return false;
        }
        return true;
    }

    public Creature GetCreature()
    {
        var creature = GetComponent<Creature>();
        if(creature)
        {
            return creature;
        }
        return null;
    }
}
