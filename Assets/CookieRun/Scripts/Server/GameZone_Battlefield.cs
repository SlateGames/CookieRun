using UnityEngine;

public class GameZone_Battlefield : GameZone_Base
{
    //TODO: Move to a Consts file
    public const int MAX_COOKIE_COUNT = 2;

    public GameZone_Battlefield()
    {
        Debug.Log("GameZone_Battlefield::GameZone_Battlefield");
        ZoneType = GameZoneType.Battlefield;
    }

    public override bool CanAddCardToZone(int cardMatchId)
    {
        return CardsInZone.Count < MAX_COOKIE_COUNT;
    }
}
