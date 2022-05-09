using System.Collections.Generic;
public abstract class BaseState
{
    public List<BaseState> NextStates = new List<BaseState>();
    public abstract void EnterState(StateMachine entity);

    public abstract void OnState(StateMachine entity);
}
