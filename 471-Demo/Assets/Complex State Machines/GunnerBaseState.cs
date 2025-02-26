using UnityEngine;

public abstract class GunnerBaseState
{
    public abstract void EnterState(UniGunner Player);

    public abstract void UpdateState(UniGunner Player);
}
