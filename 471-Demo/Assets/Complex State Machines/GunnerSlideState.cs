using UnityEngine;

public class GunnerSlideState : GunnerBaseState
{
    float starttime;

    public override void EnterState(UniGunner Player)
    {
        //Debug.Log("I'M SLIDIN EREEE!!!");
        starttime = Time.time;
    }

    public override void UpdateState(UniGunner Player)
    {
        //WHAT ARE WE DOINGGGGGGGGGG
        Player.CAMERALOOKY();
        Player.MovePlayer(Player.default_speed * 4);

        Player.isSliding = true;
        Player.gameObject.transform.localScale = new Vector3 (1,Player.slideScale,1);
        Player.gameObject.transform.localPosition = new Vector3(Player.PlayerObject.position.x, Player.slideSize, Player.PlayerObject.position.z);
        //Player.MinigunSize.transform.localPosition = new Vector3(Player.MinigunSize.position.x, Player.slideSize, Player.MinigunSize.position.z);

        //ON WHAT CONDITIONS DO WE LEAVE THE STATE?
        if (Player.movement.magnitude < 0.1)
        {
            Player.gameObject.transform.localScale = new Vector3 (1,1,1);
            Player.gameObject.transform.localPosition = new Vector3(Player.PlayerObject.position.x, Player.normalSize, Player.PlayerObject.position.z);
            //Player.MinigunSize.transform.localPosition = new Vector3(Player.MinigunSize.position.x, Player.slideSize, Player.MinigunSize.position.z);
            Player.SwitchState(Player.idleState);
        } else if (Player.isSneaking == false || Time.time - starttime > 1)
        {
            Player.gameObject.transform.localScale = new Vector3 (1,1,1);
            Player.gameObject.transform.localPosition = new Vector3(Player.PlayerObject.position.x, Player.normalSize, Player.PlayerObject.position.z);
            //Player.MinigunSize.transform.localPosition = new Vector3(Player.MinigunSize.position.x, Player.slideSize, Player.MinigunSize.position.z);

            Player.SwitchState(Player.walkState);
        }
    }
}
