using UnityEngine;

public class GunnerSprintState : GunnerBaseState
{
    float starttime;

    public override void EnterState(UniGunner Player)
    {
        //Debug.Log("I'M SPRINTING EREEE!!!");
        starttime = Time.time;
    }

    public override void UpdateState(UniGunner Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.ApplyGravity();
        Player.CAMERALOOKY();
        Player.MovePlayer(Player.default_speed * 3);

        Player.isSliding = false;

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude < 0.1)
        {
            Player.SwitchState(Player.idleState);
        } else if (Player.isSprinting == false)
        {
            Player.SwitchState(Player.walkState);
        } else if (Player.isSprinting && Player.isSneaking && Time.time - starttime > 1)
        {
            Player.SwitchState(Player.slideState);
        }
        

    }
}

