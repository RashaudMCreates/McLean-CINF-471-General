using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager Player)
    {
        Debug.Log("I'M WALKIN EREEE!!!");
    }

    public override void UpdateState(PlayerStateManager Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.MovePlayer(Player.default_speed);

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude < 0.1)
        {
            Player.SwitchState(Player.idleState);
        } else if (Player.isSneaking)
        {
            Player.SwitchState(Player.sneakState);
        }
    }
}
