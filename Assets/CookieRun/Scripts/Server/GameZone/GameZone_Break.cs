using UnityEngine;

public class GameZone_Break : GameZone_Base
{
    public GameZone_Break()
    {
        Debug.Log("GameZone_Break::GameZone_Break");
        ZoneType = GameZoneType.Break;
    }
}
