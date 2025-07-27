using UnityEngine;

public class GameZone_Battle : GameZone_Base
{
    //TODO: Move to a Consts file
    public const int MAX_COOKIE_COUNT = 2;

    public GameZone_Battle()
    {
        Debug.Log("GameZone_Battle::GameZone_Battle");
        ZoneType = GameZoneType.Battle;
    }

    public override bool CanAddCardToZone(int cardMatchId)
    {
        return CardsInZone.Count < MAX_COOKIE_COUNT;
    }
}
