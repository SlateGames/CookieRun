using System.Collections.Generic;
using UnityEngine;

public class AffogatoCookie : Card_Cookie
{
    public override string CardId => "76926";
    public override string CardNumber => "BS1-009";
    public override string CardName => "Affogato Cookie";
    public override string CardText => "【Blocker】 《{R}》 (When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.)《{R}{N}》 Deals 1 damage.";
    public override CardRarity CardRarity => CardRarity.Rare;
    public override CardType CardType => CardType.Cookie;
    public override CardColour ColourIdentity => CardColour.Red;
    public override string ImageName => "BS1_009.png";
    public override int CardHealth => 3;
    public override int CardLevel => 1;

    public AffogatoCookie()
    {
        Debug.Log("AffogatoCookie::AffogatoCookie");

        CardAbility cardAbility01 = new CardAbility();
        cardAbility01.AbilityText = "When one of your opponent's Cookies attacks, you can redirect the attack to this Cookie.";
        cardAbility01.Qualifiers.Add(AbilityQualifier.Blocker);
        cardAbility01.ManaCost.Add(CardColour.Red);

        CardAbility cardAbility02 = new CardAbility();
        cardAbility02.AbilityText = "Deals 1 damage.";
        cardAbility02.ManaCost.Add(CardColour.Mix);
        cardAbility02.ManaCost.Add(CardColour.Red);

        _abilities.Add(cardAbility01);
        _abilities.Add(cardAbility02);
    }

    public override void ActivateAbility(AbilityContextData abilityContext)
    {
        Debug.Log("AffogatoCookie::ActivateAbility");

        if (abilityContext.AbilityId == 0)
        {
            //TODO: Request this from the player
        }
        if (abilityContext.AbilityId == 1)
        {
            RulesEngine.Instance.GetGameStateManager().DealDamageToCookie(MatchID, abilityContext.TargetMatchIds[0], 1);
        }
    }
}