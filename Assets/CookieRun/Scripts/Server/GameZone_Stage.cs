using System.Linq;
using UnityEngine;

public class GameZone_Stage : GameZone_Base
{
    public GameZone_Stage()
    {
        Debug.Log("GameZone_Stage::GameZone_Stage");
        ZoneType = GameZoneType.Stage;
    }

    public override void AddCard(int cardMatchId)
    {
        RemoveCard(CardsInZone.First());
        base.AddCard(cardMatchId);
    }
}
