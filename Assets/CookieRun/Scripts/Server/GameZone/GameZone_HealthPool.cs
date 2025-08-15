using UnityEngine;

public class GameZone_HealthPool : GameZone_Base
{
    public GameZone_HealthPool()
    {
        Debug.Log("GameZone_HealthPool::GameZone_HealthPool");
        ZoneType = GameZoneType.HealthPool;
    }
}
