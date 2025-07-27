using UnityEngine;

public class GameZone_Trash : GameZone_Base
{
    public GameZone_Trash()
    {
        Debug.Log("GameZone_Trash::GameZone_Trash");
        ZoneType = GameZoneType.Trash;
    }
}
