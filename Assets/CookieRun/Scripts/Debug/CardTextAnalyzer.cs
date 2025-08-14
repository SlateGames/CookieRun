//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;
//using UnityEngine;

//[System.Serializable]
//public class CardAnalysis
//{
//    public string cardName;
//    public string originalText;
//    public List<CardAbility> abilities = new List<CardAbility>();
//}

//public class CardTextAnalyzer : MonoBehaviour
//{
//    private List<Card_Base> allCards = new List<Card_Base>();
//    private static readonly HashSet<string> MANA_COLORS = new HashSet<string>
//    {
//        "R", "Y", "G", "B", "P"
//    };

//    private void Start()
//    {
//        LoadAllCards();
//        AnalyzeAllCards();
//    }

//    public void AnalyzeAllCards()
//    {
//        List<CardAnalysis> allAnalyses = new List<CardAnalysis>();

//        foreach (Card_Base card in allCards)
//        {
//            if (!string.IsNullOrEmpty(card.CardText))
//            {
//                CardAnalysis analysis = AnalyzeCardText(card.CardText, card.name);
//                allAnalyses.Add(analysis);
//            }
//        }

//        WriteAnalysisToFile(allAnalyses);
//    }

//    public CardAnalysis AnalyzeCardText(string cardText, string cardName = "Unknown")
//    {
//        CardAnalysis analysis = new CardAnalysis
//        {
//            cardName = cardName,
//            originalText = cardText
//        };

//        List<string> abilityTexts = new List<string>();

//        string mainText = cardText;
//        string flipText = "";

//        int flipIndex = cardText.IndexOf("FLIP");
//        if (flipIndex != -1)
//        {
//            mainText = cardText.Substring(0, flipIndex).Trim();
//            flipText = cardText.Substring(flipIndex).Trim();
//        }

//        if (!string.IsNullOrEmpty(mainText))
//        {
//            List<int> costPositions = new List<int>();

//            for (int i = 0; i < mainText.Length; i++)
//            {
//                if (mainText[i] == '《')
//                {
//                    costPositions.Add(i);
//                }
//            }

//            if (costPositions.Count <= 1)
//            {
//                abilityTexts.Add(mainText);
//            }
//            else
//            {
//                int startIndex = 0;

//                for (int i = 1; i < costPositions.Count; i++)
//                {
//                    int splitIndex = costPositions[i];
//                    string ability = mainText.Substring(startIndex, splitIndex - startIndex).Trim();
//                    if (!string.IsNullOrWhiteSpace(ability))
//                    {
//                        abilityTexts.Add(ability);
//                    }
//                    startIndex = splitIndex;
//                }

//                string finalMainAbility = mainText.Substring(startIndex).Trim();
//                if (!string.IsNullOrWhiteSpace(finalMainAbility))
//                {
//                    abilityTexts.Add(finalMainAbility);
//                }
//            }
//        }

//        if (!string.IsNullOrEmpty(flipText))
//        {
//            abilityTexts.Add(flipText);
//        }

//        foreach (string abilityText in abilityTexts)
//        {
//            CardAbility ability = AnalyzeAbility(abilityText.Trim());
//            analysis.abilities.Add(ability);
//        }

//        return analysis;
//    }

//    private CardAbility AnalyzeAbility(string abilityText)
//    {
//        CardAbility ability = new CardAbility();
//        string remainingText = abilityText;

//        ability.Costs = ExtractCosts(ref remainingText);
//        ability.Qualifiers = ExtractQualifiers(ref remainingText);
//        ability.AbilityText = remainingText.Trim();

//        return ability;
//    }

//    private List<Cost> ExtractCosts(ref string text)
//    {
//        List<Cost> costs = new List<Cost>();

//        Regex costRegex = new Regex(@"《([^》]*)》");
//        MatchCollection matches = costRegex.Matches(text);

//        foreach (Match match in matches)
//        {
//            string costText = match.Groups[1].Value.Trim();
//            Cost cost = new Cost
//            {
//                CostText = costText,
//                IsMana = IsMana(costText)
//            };

//            if (cost.IsMana)
//            {
//                cost.ManaColour = ExtractManaColor(costText);
//            }

//            costs.Add(cost);
//        }

//        text = costRegex.Replace(text, "").Trim();
//        return costs;
//    }

//    private List<string> ExtractQualifiers(ref string text)
//    {
//        List<string> qualifiers = new List<string>();

//        if (text.StartsWith("FLIP"))
//        {
//            qualifiers.Add("FLIP");
//            text = text.Substring(4).Trim();
//        }

//        Regex qualifierRegex = new Regex(@"【([^】]*)】");
//        MatchCollection matches = qualifierRegex.Matches(text);

//        foreach (Match match in matches)
//        {
//            string qualifier = match.Groups[1].Value.Trim();
//            if (!string.IsNullOrEmpty(qualifier))
//            {
//                qualifiers.Add(qualifier);
//            }
//        }

//        text = qualifierRegex.Replace(text, "").Trim();

//        return qualifiers;
//    }

//    private bool IsMana(string costText)
//    {
//        Regex manaRegex = new Regex(@"\{([RYGBP])\}");
//        return manaRegex.IsMatch(costText);
//    }

//    private string ExtractManaColor(string costText)
//    {
//        Regex manaRegex = new Regex(@"\{([RYGBP])\}");
//        Match match = manaRegex.Match(costText);

//        if (match.Success)
//        {
//            string color = match.Groups[1].Value;
//            return GetFullColorName(color);
//        }

//        return "";
//    }

//    private string GetFullColorName(string colorCode)
//    {
//        switch (colorCode)
//        {
//            case "R": return "Red";
//            case "Y": return "Yellow";
//            case "G": return "Green";
//            case "B": return "Blue";
//            case "P": return "Purple";
//            default: return colorCode;
//        }
//    }

//    private void WriteAnalysisToFile(List<CardAnalysis> analyses)
//    {
//        string filePath = Path.Combine(Application.persistentDataPath, "card_analysis.txt");

//        try
//        {
//            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
//            {
//                writer.WriteLine("=== CARD TEXT ANALYSIS REPORT ===");
//                writer.WriteLine($"Generated: {DateTime.Now}");
//                writer.WriteLine($"Total Cards Analyzed: {analyses.Count}");
//                writer.WriteLine();

//                foreach (CardAnalysis analysis in analyses)
//                {
//                    WriteCardAnalysis(writer, analysis);
//                }

//                // Collect unique data for summary
//                HashSet<string> uniqueQualifiers = new HashSet<string>();
//                HashSet<string> uniqueAbilityTexts = new HashSet<string>();
//                HashSet<string> uniqueManaCosts = new HashSet<string>();
//                HashSet<string> uniqueNonManaCosts = new HashSet<string>();

//                foreach (CardAnalysis analysis in analyses)
//                {
//                    foreach (CardAbility ability in analysis.abilities)
//                    {
//                        // Collect qualifiers
//                        foreach (string qualifier in ability.Qualifiers)
//                        {
//                            if (!string.IsNullOrEmpty(qualifier))
//                            {
//                                uniqueQualifiers.Add(qualifier);
//                            }
//                        }

//                        // Collect ability texts
//                        if (!string.IsNullOrEmpty(ability.AbilityText))
//                        {
//                            uniqueAbilityTexts.Add(ability.AbilityText);
//                        }

//                        // Collect costs
//                        foreach (Cost cost in ability.Costs)
//                        {
//                            if (!string.IsNullOrEmpty(cost.CostText))
//                            {
//                                if(cost.IsMana)
//                                {
//                                    uniqueManaCosts.Add(cost.CostText);
//                                }
//                                else
//                                {
//                                    uniqueNonManaCosts.Add(cost.CostText);
//                                }
//                            }
//                        }
//                    }
//                }

//                // Write summary lists
//                writer.WriteLine();
//                writer.WriteLine("=== SUMMARY LISTS ===");
//                writer.WriteLine();

//                writer.WriteLine($"ALL UNIQUE QUALIFIERS ({uniqueQualifiers.Count}):");
//                foreach (string qualifier in uniqueQualifiers.OrderBy(q => q))
//                {
//                    writer.WriteLine($"  - {qualifier}");
//                }
//                writer.WriteLine();

//                writer.WriteLine($"ALL UNIQUE ABILITY TEXTS ({uniqueAbilityTexts.Count}):");
//                foreach (string abilityText in uniqueAbilityTexts.OrderBy(a => a))
//                {
//                    writer.WriteLine($"  - {abilityText}");
//                }
//                writer.WriteLine();

//                writer.WriteLine($"ALL UNIQUE MANA COSTS ({uniqueManaCosts.Count}):");
//                foreach (string cost in uniqueManaCosts.OrderBy(c => c))
//                {
//                    writer.WriteLine($"  - {cost}");
//                }
//                writer.WriteLine();

//                writer.WriteLine($"ALL UNIQUE NON-MANA COSTS ({uniqueNonManaCosts.Count}):");
//                foreach (string cost in uniqueNonManaCosts.OrderBy(c => c))
//                {
//                    writer.WriteLine($"  - {cost}");
//                }
//            }

//            Debug.Log($"Card analysis written to: {filePath}");
//        }
//        catch (Exception ex)
//        {
//            Debug.LogError($"Failed to write card analysis to file: {ex.Message}");
//        }
//    }

//    private void WriteCardAnalysis(StreamWriter writer, CardAnalysis analysis)
//    {
//        writer.WriteLine($"CARD: {analysis.cardName}");
//        writer.WriteLine($"Original Text: {analysis.originalText}");
//        writer.WriteLine($"Abilities Found: {analysis.abilities.Count}");
//        writer.WriteLine();

//        for (int i = 0; i < analysis.abilities.Count; i++)
//        {
//            CardAbility ability = analysis.abilities[i];
//            writer.WriteLine($"  Ability {i + 1}:");

//            if (ability.Costs.Count > 0)
//            {
//                writer.WriteLine($"    Costs ({ability.Costs.Count}):");
//                foreach (Cost cost in ability.Costs)
//                {
//                    writer.WriteLine($"      - {cost.CostText} (Mana: {cost.IsMana})");
//                    if (cost.IsMana && !string.IsNullOrEmpty(cost.ManaColour))
//                    {
//                        writer.WriteLine($"        Color: {cost.ManaColour}");
//                    }
//                }
//            }

//            if (ability.Qualifiers.Count > 0)
//            {
//                writer.WriteLine($"    Qualifiers ({ability.Qualifiers.Count}):");
//                foreach (string qualifier in ability.Qualifiers)
//                {
//                    writer.WriteLine($"      - {qualifier}");
//                }
//            }

//            if (!string.IsNullOrEmpty(ability.AbilityText))
//            {
//                writer.WriteLine($"    Ability Text: {ability.AbilityText}");
//            }

//            writer.WriteLine();
//        }

//        writer.WriteLine("----------------------------------------");
//        writer.WriteLine();
//    }

//    private void LoadAllCards()
//    {
//        List<Type> cardTypes = GetAllCardTypes();

//        foreach (Type cardType in cardTypes)
//        {
//            Card_Base cardInstance = (Card_Base)Activator.CreateInstance(cardType);
//            if (cardInstance == null || string.IsNullOrEmpty(cardInstance.ImageName))
//            {
//                continue;
//            }

//            allCards.Add(cardInstance);
//        }

//        Debug.Log($"Loaded {allCards.Count} cards into deck editor");
//    }

//    private List<Type> GetAllCardTypes()
//    {
//        List<Type> cardTypes = new List<Type>();
//        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

//        foreach (Assembly assembly in assemblies)
//        {
//            try
//            {
//                List<Type> types = assembly.GetTypes()
//                    .Where(t => t.IsSubclassOf(typeof(Card_Base)) && !t.IsAbstract)
//                    .ToList();

//                cardTypes.AddRange(types);
//            }
//            catch (ReflectionTypeLoadException ex)
//            {
//                Debug.LogWarning($"Could not load some types from assembly {assembly.FullName}: {ex.Message}");
//            }
//        }

//        return cardTypes;
//    }
//}