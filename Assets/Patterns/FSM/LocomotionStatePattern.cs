using UnityEngine;

public interface LocomotionContext
{
    void SetState(LocomotionState newState);
}

public interface LocomotionState
{
    void Jump(LocomotionContext context);
    void Fall(LocomotionContext context);
    void Land(LocomotionContext context);
    void Crouch(LocomotionContext context);
}


public class LocomotionStatePattern : MonoBehaviour, LocomotionContext
{
    LocomotionState currentState = new GroundedState();

    public void Crouch() => currentState.Crouch(this);
    public void Jump() => currentState.Jump(this);
    public void Fall() => currentState.Fall(this);
    public void Land() => currentState.Land(this);

    public void SetState(LocomotionState newState)
    {
        currentState = newState;
    }

}

public class GroundedState: LocomotionState
{
    public void Jump(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Fall(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Land(LocomotionContext context)
    {
        // No transition needed
    }

    public void Crouch(LocomotionContext context)
    {
        context.SetState(new CrouchingState());
    }
}

public class InAirState : LocomotionState
{
    public void Jump(LocomotionContext context)
    {
        // Already in air, cannot jump again
    }

    public void Fall(LocomotionContext context)
    {
        // Already falling, no transition needed
    }

    public void Land(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    public void Crouch(LocomotionContext context)
    {
        // Cannot crouch in air
    }
}


public class CrouchingState : LocomotionState
{
    public void Jump(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    public void Fall(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Land(LocomotionContext context)
    {
    }

    public void Crouch(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
}
