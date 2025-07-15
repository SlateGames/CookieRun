using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class CookieRunCardDownloader : MonoBehaviour
{
    [Header("Download Settings")]
    public string cardJsonUrl = "https://cookierunbraverse.com/en/cardList/card.json";
    public string cardImageBaseUrl = "https://assets.cookierunbraverse.com/braverse/images/card_webp/card/en/";
    public string cardImageFormat = "BS1_{0:000}.png.webp";

    [Header("File Names")]
    public string cardDataFileName = "cardData.json";
    public string cardImageFolderName = "CardImages";

    [Header("Status")]
    public bool isDownloading = false;
    public string lastError = "";

    // Events
    public System.Action<string> OnDownloadComplete;
    public System.Action<string> OnDownloadError;
    public System.Action<string, float> OnDownloadProgress;

    [System.Serializable]
    public class CardData
    {
        public int id;
        public int elementId;
        public string title;
        public string artistTitle;
        public string productTitle;
        public string cardDesc;
        public string rarity;
        public string hp;
        public string cardNo;
        public string grade;
        public string cardImage;
        public string productCategory;
        public string productCategoryTitle;
        public long postDate;
        public string cardType;
        public string cardTypeTitle;
        public string energyType;
        public string energyTypeTitle;
        public string cardLevel;
        public string cardLevelTitle;
    }

    private List<CardData> parsedCards = new List<CardData>();

    private void Start()
    {
        //ParseCardData();
        //DownloadCardJson();
        //DownloadAllCardImages();
    }

    /// <summary>
    /// Downloads the card JSON data from the server
    /// </summary>
    public void DownloadCardJson()
    {
        if (isDownloading)
        {
            Debug.LogWarning("Download already in progress!");
            return;
        }

        StartCoroutine(DownloadCardJsonCoroutine());
    }

    private IEnumerator DownloadCardJsonCoroutine()
    {
        isDownloading = true;
        lastError = "";

        Debug.Log("Starting card JSON download...");
        OnDownloadProgress?.Invoke("Downloading card JSON...", 0f);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(cardJsonUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                lastError = $"Failed to download card JSON: {webRequest.error}";
                Debug.LogError(lastError);
                OnDownloadError?.Invoke(lastError);
                isDownloading = false;
                yield break;
            }

            string jsonData = webRequest.downloadHandler.text;
            string filePath = Path.Combine(Application.persistentDataPath, cardDataFileName);

            try
            {
                File.WriteAllText(filePath, jsonData);
                Debug.Log($"Card JSON saved to: {filePath}");
                OnDownloadComplete?.Invoke(filePath);
            }
            catch (System.Exception ex)
            {
                lastError = $"Failed to save card JSON: {ex.Message}";
                Debug.LogError(lastError);
                OnDownloadError?.Invoke(lastError);
            }
        }

        isDownloading = false;
    }

    /// <summary>
    /// Downloads a single card image by card number
    /// </summary>
    public void DownloadSingleCardImage(int cardNumber)
    {
        if (isDownloading)
        {
            Debug.LogWarning("Download already in progress!");
            return;
        }

        StartCoroutine(DownloadSingleCardImageCoroutine(cardNumber));
    }

    private IEnumerator DownloadSingleCardImageCoroutine(int cardNumber)
    {
        isDownloading = true;
        lastError = "";

        string imageUrl = cardImageBaseUrl + string.Format(cardImageFormat, cardNumber);
        string fileName = string.Format("BS1_{0:000}.png.webp", cardNumber);

        Debug.Log($"Downloading card image: {imageUrl}");
        OnDownloadProgress?.Invoke($"Downloading card {cardNumber:000}...", 0f);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(imageUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                lastError = $"Failed to download card image {cardNumber}: {webRequest.error}";
                Debug.LogError(lastError);
                OnDownloadError?.Invoke(lastError);
                isDownloading = false;
                yield break;
            }

            byte[] imageData = webRequest.downloadHandler.data;
            string folderPath = Path.Combine(Application.persistentDataPath, cardImageFolderName);

            // Create folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                File.WriteAllBytes(filePath, imageData);
                Debug.Log($"Card image saved to: {filePath}");
                OnDownloadComplete?.Invoke(filePath);
            }
            catch (System.Exception ex)
            {
                lastError = $"Failed to save card image: {ex.Message}";
                Debug.LogError(lastError);
                OnDownloadError?.Invoke(lastError);
            }
        }

        isDownloading = false;
    }

    /// <summary>
    /// Downloads all card images from 001 to 081
    /// </summary>
    public void DownloadAllCardImages()
    {
        if (isDownloading)
        {
            Debug.LogWarning("Download already in progress!");
            return;
        }

        StartCoroutine(DownloadAllCardImagesCoroutine());
    }

    private IEnumerator DownloadAllCardImagesCoroutine()
    {
        isDownloading = true;
        lastError = "";

        Debug.Log("Starting download of all card images (001-081)...");

        string folderPath = Path.Combine(Application.persistentDataPath, cardImageFolderName);

        // Create folder if it doesn't exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        int totalCards = 81;
        int downloadedCards = 0;
        int failedDownloads = 0;

        for (int cardNumber = 1; cardNumber <= totalCards; cardNumber++)
        {
            string imageUrl = cardImageBaseUrl + string.Format(cardImageFormat, cardNumber);
            string fileName = string.Format("BS1_{0:000}.png.webp", cardNumber);

            Debug.Log($"Downloading card {cardNumber}/81: {imageUrl}");
            OnDownloadProgress?.Invoke($"Downloading card {cardNumber}/81...", (float)cardNumber / totalCards);

            using (UnityWebRequest webRequest = UnityWebRequest.Get(imageUrl))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    byte[] imageData = webRequest.downloadHandler.data;
                    string filePath = Path.Combine(folderPath, fileName);

                    try
                    {
                        File.WriteAllBytes(filePath, imageData);
                        downloadedCards++;
                        Debug.Log($"Card {cardNumber:000} saved successfully");
                    }
                    catch (System.Exception ex)
                    {
                        failedDownloads++;
                        Debug.LogError($"Failed to save card {cardNumber}: {ex.Message}");
                    }
                }
                else
                {
                    failedDownloads++;
                    Debug.LogError($"Failed to download card {cardNumber}: {webRequest.error}");
                }
            }

            // Small delay between downloads to be nice to the server
            yield return new WaitForSeconds(0.1f);
        }

        isDownloading = false;

        string resultMessage = $"Download complete! {downloadedCards} cards downloaded, {failedDownloads} failed";
        Debug.Log(resultMessage);
        OnDownloadComplete?.Invoke(resultMessage);
    }

    /// <summary>
    /// Parses the downloaded card JSON and extracts each element with safety checks
    /// </summary>
    public void ParseCardData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, cardDataFileName);

        if (!File.Exists(filePath))
        {
            lastError = "Card JSON file not found. Please download it first.";
            Debug.LogError(lastError);
            OnDownloadError?.Invoke(lastError);
            return;
        }

        try
        {
            string jsonData = File.ReadAllText(filePath);
            Debug.Log("Starting to parse card data...");

            // Parse JSON array
            jsonData = jsonData.Trim();
            if (!jsonData.StartsWith("["))
            {
                jsonData = "[" + jsonData + "]";
            }

            // Simple JSON parsing - Unity's JsonUtility doesn't handle arrays directly
            parsedCards.Clear();

            // Remove outer brackets and split by objects
            jsonData = jsonData.Substring(1, jsonData.Length - 2);
            string[] cardObjects = SplitJsonObjects(jsonData);

            int skippedCards = 0;
            int createdClassFiles = 0;

            foreach (string cardJson in cardObjects)
            {
                if (string.IsNullOrEmpty(cardJson.Trim()))
                    continue;

                try
                {
                    CardData card = ParseSingleCard(cardJson);
                    if (card != null)
                    {
                        // Check if field_cardNo_suyeowsc begins with BS1 or BS2
                        if (!card.cardNo.StartsWith("BS1") && !card.cardNo.StartsWith("BS2"))
                        {
                            skippedCards++;
                            continue;
                        }

                        // Check if the field contains a "@" in the value
                        if (card.cardNo.Contains("@"))
                        {
                            skippedCards++;
                            continue;
                        }

                        // Add to parsed cards
                        parsedCards.Add(card);

                        // Create the card class file
                        bool fileCreated = CreateCardClassFile(card);
                        if (fileCreated)
                        {
                            createdClassFiles++;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.LogError($"Failed to parse card: {ex.Message}");
                }
            }

            Debug.Log($"Successfully parsed {parsedCards.Count} cards");
            Debug.Log($"Skipped {skippedCards} cards (not BS1/BS2 or contains @)");
            Debug.Log($"Created {createdClassFiles} card class files");

            // Print some example data
            if (parsedCards.Count > 0)
            {
                CardData firstCard = parsedCards[0];
                Debug.Log($"Example card - Title: {firstCard.title}, Type: {firstCard.cardType}, HP: {firstCard.hp}");
            }
        }
        catch (System.Exception ex)
        {
            lastError = $"Failed to parse card data: {ex.Message}";
            Debug.LogError(lastError);
            OnDownloadError?.Invoke(lastError);
        }
    }

    private string[] SplitJsonObjects(string jsonArray)
    {
        List<string> objects = new List<string>();
        int braceCount = 0;
        int startIndex = 0;

        for (int i = 0; i < jsonArray.Length; i++)
        {
            if (jsonArray[i] == '{')
            {
                if (braceCount == 0)
                    startIndex = i;
                braceCount++;
            }
            else if (jsonArray[i] == '}')
            {
                braceCount--;
                if (braceCount == 0)
                {
                    objects.Add(jsonArray.Substring(startIndex, i - startIndex + 1));
                }
            }
        }

        return objects.ToArray();
    }

    private CardData ParseSingleCard(string cardJson)
    {
        CardData card = new CardData();

        // Parse each field with safety checks
        card.id = ParseIntField(cardJson, "id");
        card.elementId = ParseIntField(cardJson, "elementId");
        card.title = ParseStringField(cardJson, "title");
        card.artistTitle = ParseStringField(cardJson, "field_artistTitle");
        card.productTitle = ParseStringField(cardJson, "field_productTitle");
        card.cardDesc = ParseStringField(cardJson, "field_cardDesc");
        card.rarity = ParseStringField(cardJson, "field_rare_tzsrperf");
        card.hp = ParseStringField(cardJson, "field_hp_zbxcocvx");
        card.cardNo = ParseStringField(cardJson, "field_cardNo_suyeowsc");
        card.grade = ParseStringField(cardJson, "field_grade");
        card.cardImage = ParseStringField(cardJson, "cardImage");
        card.productCategory = ParseStringField(cardJson, "productCategory");
        card.productCategoryTitle = ParseStringField(cardJson, "productCategoryTitle");
        card.postDate = ParseLongField(cardJson, "postDate");
        card.cardType = ParseStringField(cardJson, "cardType");
        card.cardTypeTitle = ParseStringField(cardJson, "cardTypeTitle");
        card.energyType = ParseStringField(cardJson, "energyType");
        card.energyTypeTitle = ParseStringField(cardJson, "energyTypeTitle");
        card.cardLevel = ParseStringField(cardJson, "cardLevel");
        card.cardLevelTitle = ParseStringField(cardJson, "cardLevelTitle");

        return card;
    }

    private string ParseStringField(string json, string fieldName)
    {
        try
        {
            string pattern = $"\"{fieldName}\"\\s*:\\s*\"([^\"]*?)\"";
            var match = System.Text.RegularExpressions.Regex.Match(json, pattern);
            if (match.Success)
            {
                return match.Groups[1].Value.Replace("\\\"", "\"").Replace("\\n", "\n");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Failed to parse string field '{fieldName}': {ex.Message}");
        }

        return "";
    }

    private int ParseIntField(string json, string fieldName)
    {
        try
        {
            string pattern = $"\"{fieldName}\"\\s*:\\s*(\\d+)";
            var match = System.Text.RegularExpressions.Regex.Match(json, pattern);
            if (match.Success)
            {
                if (int.TryParse(match.Groups[1].Value, out int result))
                {
                    return result;
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Failed to parse int field '{fieldName}': {ex.Message}");
        }

        return 0;
    }

    private long ParseLongField(string json, string fieldName)
    {
        try
        {
            string pattern = $"\"{fieldName}\"\\s*:\\s*(\\d+)";
            var match = System.Text.RegularExpressions.Regex.Match(json, pattern);
            if (match.Success)
            {
                if (long.TryParse(match.Groups[1].Value, out long result))
                {
                    return result;
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"Failed to parse long field '{fieldName}': {ex.Message}");
        }

        return 0;
    }

    /// <summary>
    /// Returns the parsed card data
    /// </summary>
    public List<CardData> GetParsedCards()
    {
        return parsedCards;
    }

    /// <summary>
    /// Returns the folder path where card images are stored
    /// </summary>
    public string GetCardImageFolderPath()
    {
        return Path.Combine(Application.persistentDataPath, cardImageFolderName);
    }

    /// <summary>
    /// Returns the file path where card JSON is stored
    /// </summary>
    public string GetCardJsonFilePath()
    {
        return Path.Combine(Application.persistentDataPath, cardDataFileName);
    }

    /// <summary>
    /// Checks if a specific card image exists
    /// </summary>
    public bool CardImageExists(int cardNumber)
    {
        string fileName = string.Format("BS1_{0:000}.png.webp", cardNumber);
        string filePath = Path.Combine(GetCardImageFolderPath(), fileName);
        return File.Exists(filePath);
    }

    /// <summary>
    /// Creates a card class file based on the card data
    /// </summary>
    private bool CreateCardClassFile(CardData card)
    {
        try
        {
            string outputPath = @"D:\Projects\CookieRun\Assets\CookieRun\Cards\BraveBeginnings";

            // Create directory if it doesn't exist
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // Clean card name for class name
            string cleanCardName = CleanStringForClassName(card.title);
            string cardType = card.cardType.ToLower();
            cardType = char.ToUpper(cardType[0]) + cardType.Substring(1);

            // Determine base class and card type enum
            string baseClass = GetBaseClass(cardType);
            CardType cardTypeEnum = GetCardTypeEnum(cardType);

            if (baseClass == null)
            {
                Debug.LogWarning($"Unknown card type: {cardType} for card {card.title}");
                return false;
            }

            // Create class name
            string className = $"Card_{cardType}_{cleanCardName}";

            // Generate class content
            string classContent = GenerateCardClassContent(className, baseClass, card, cardTypeEnum);

            // Save to file
            string fileName = $"{className}.cs";
            string filePath = Path.Combine(outputPath, fileName);

            File.WriteAllText(filePath, classContent);

            Debug.Log($"Created card class file: {filePath}");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to create card class file for {card.title}: {ex.Message}");
            return false;
        }
    }

    private string CleanStringForClassName(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "Unknown";

        // Remove HTML tags
        string cleaned = System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", "");

        // Replace spaces and special characters with underscore
        cleaned = System.Text.RegularExpressions.Regex.Replace(cleaned, "[^a-zA-Z0-9]", "");

        // Remove multiple underscores
        cleaned = System.Text.RegularExpressions.Regex.Replace(cleaned, "_+", "");

        // Remove leading/trailing underscores
        cleaned = cleaned.Trim('_');

        // Ensure it starts with a letter
        if (cleaned.Length > 0 && char.IsDigit(cleaned[0]))
        {
            cleaned = "Card_" + cleaned;
        }

        return cleaned;
    }

    private string GetBaseClass(string cardType)
    {
        switch (cardType.ToLower())
        {
            case "cookie":
                return "Card_Cookie";
            case "item":
                return "Card_Item";
            case "stage":
                return "Card_Stage";
            case "trap":
                return "Card_Trap";
            default:
                return null;
        }
    }

    private CardType GetCardTypeEnum(string cardType)
    {
        switch (cardType.ToLower())
        {
            case "cookie":
                return CardType.Cookie;
            case "item":
                return CardType.Item;
            case "stage":
                return CardType.Stage;
            case "trap":
                return CardType.Trap;
            default:
                return CardType.Invalid;
        }
    }

    private CardRarity GetCardRarityEnum(string rarity)
    {
        switch (rarity.ToUpperInvariant())
        {
            case "C":
                return CardRarity.Common;
            case "U":
                return CardRarity.Uncommon;
            case "R":
                return CardRarity.Rare;
            case "SR":
                return CardRarity.SuperRare;
            case "UR":
                return CardRarity.UltraRare;
            case "ER":
                return CardRarity.ExtraRare;
            case "SEC":
                return CardRarity.SecretRare;
            case "SSR":
                return CardRarity.SuperSecretRare;
            case "USR":
                return CardRarity.UltraSecretRare;
            case "P":
                return CardRarity.Promotion;
            default:
                return CardRarity.Common; // fallback
        }
    }


    private CardColour GetCardColourEnum(string energyType)
    {
        switch (energyType.ToLower())
        {
            case "red":
                return CardColour.Red;
            case "blue":
                return CardColour.Blue;
            case "green":
                return CardColour.Green;
            case "yellow":
                return CardColour.Yellow;
            case "purple":
                return CardColour.Purple;
            default:
                return CardColour.Invalid;
        }
    }

    private string GenerateCardClassContent(string className, string baseClass, CardData card, CardType cardTypeEnum)
    {
        CardRarity rarity = GetCardRarityEnum(card.rarity);
        CardColour colour = GetCardColourEnum(card.energyType);

        // Clean card description (remove HTML tags)
        string cleanDescription = System.Text.RegularExpressions.Regex.Replace(card.cardDesc, "<.*?>", "");
        cleanDescription = cleanDescription.Replace("\"", "\\\"").Replace("\n", "\\n");

        // Get image path
        string imagePath = card.cardImage.Replace("https://assets.cookierunbraverse.com/braverse/images/card_webp/card/en/", "");

        string content = $@"using UnityEngine;

public class {className} : {baseClass}
{{
    public override string CardId => ""{card.id}"";
    public override string CardNumber => ""{card.cardNo}"";
    public override string CardName => ""{card.title}"";
    public override string CardText => ""{cleanDescription}"";
    public override CardRarity CardRarity => CardRarity.{rarity};
    public override CardType CardType => CardType.{cardTypeEnum};
    public override CardColour ColourIdentity => CardColour.{colour};
    public override string ImagePath => ""{imagePath}"";";

        // Add card-specific properties for Cookie cards
        if (baseClass == "Card_Cookie")
        {
            int health = 0;
            int.TryParse(card.hp, out health);

            int level = 0;
            if (card.cardLevel.Contains("1")) level = 1;
            else if (card.cardLevel.Contains("2")) level = 2;
            else if (card.cardLevel.Contains("3")) level = 3;

            content += $@"
    public override int CardHealth => {health};
    public override int CardLevel => {level};";
        }

        content += @"
}";

        return content;
    }
}