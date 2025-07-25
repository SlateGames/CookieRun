using UnityEngine;

public class GameZone_Discard : GameZone_Base
{
    public GameZone_Discard()
    {
        Debug.Log("GameZone_Discard::GameZone_Discard");
        ZoneType = GameZoneType.Discard;
    }
}
