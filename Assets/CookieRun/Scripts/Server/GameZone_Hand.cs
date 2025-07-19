using UnityEngine;

public class GameZone_Hand : GameZone_Base
{
    public GameZone_Hand()
    {
        Debug.Log("GameZone_Hand::GameZone_Hand");
        ZoneType = GameZoneType.Hand;
    }
}
