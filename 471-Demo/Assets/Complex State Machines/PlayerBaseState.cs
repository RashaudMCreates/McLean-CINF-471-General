using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager Player);

    public abstract void UpdateState(PlayerStateManager Player);
}
