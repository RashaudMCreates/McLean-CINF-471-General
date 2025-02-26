using UnityEngine;

public class GunnerSprintState : GunnerBaseState
{
    public override void EnterState(UniGunner Player)
    {
        Debug.Log("I'M SPRINTING EREEE!!!");
    }

    public override void UpdateState(UniGunner Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.MovePlayer(Player.default_speed * 3);

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude < 0.1)
        {
            Player.SwitchState(Player.idleState);
        } else if (Player.isSprinting == false)
        {
            Player.SwitchState(Player.walkState);
        } else if (Player.isSprinting && Player.isSneaking)
        {
            Player.SwitchState(Player.slideState);
        }
        

    }
}

