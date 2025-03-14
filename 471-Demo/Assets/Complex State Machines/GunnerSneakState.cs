using UnityEngine;

public class GunnerSneakState : GunnerBaseState
{
    public override void EnterState(UniGunner Player)
    {
        //Debug.Log("I'M SNEAKIN EREEE!!!");
    }

    public override void UpdateState(UniGunner Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.ApplyGravity();
        Player.CAMERALOOKY();
        Player.MovePlayer(Player.default_speed / 2);

        Player.isSliding = false;

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude < 0.1)
        {
            Player.SwitchState(Player.idleState);
        } else if (Player.isSneaking == false)
        {
            Player.SwitchState(Player.walkState);
        }
    }
}
