using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("I'm IDLE!!!");
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude > 0.1)
        {
            if(Player.isSneaking)
            {
                Player.SwitchState(Player.sneakState);
            } else
            {
                Player.SwitchState(Player.walkState);
            }
        }
    }
}
