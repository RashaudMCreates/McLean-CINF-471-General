using UnityEngine;

public class GunnerIdleState : GunnerBaseState
{
    public override void EnterState(UniGunner Player)
    {
        Debug.Log("I'm IDLE!!!");
    }

    public override void UpdateState(UniGunner Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.ApplyGravity();
        Player.CAMERALOOKY();

        Player.isSliding = false;

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude > 0.1)
        {
            if(Player.isSneaking)
            {
                Player.SwitchState(Player.sneakState);
            } else if (Player.isSprinting)
            {
                Player.SwitchState(Player.sprintState);
            } else
            {
                Player.SwitchState(Player.walkState);
            }
        }
    }
}
