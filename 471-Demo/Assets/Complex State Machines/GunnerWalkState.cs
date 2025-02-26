using UnityEngine;

public class GunnerWalkState : GunnerBaseState
{
    public override void EnterState(UniGunner Player)
    {
        Debug.Log("I'M WALKIN EREEE!!!");
    }

    public override void UpdateState(UniGunner Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.MovePlayer(Player.default_speed);

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude < 0.1)
        {
            Player.SwitchState(Player.idleState);
        } else if (Player.isSprinting)
        {
            Player.SwitchState(Player.sprintState);
        } else if (Player.isSneaking)
        {
            Player.SwitchState(Player.sneakState);
        }
    }
}