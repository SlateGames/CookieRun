using System;
using System.Collections.Generic;
using Unity.Netcode;

public struct Deck : INetworkSerializable
{
    public string DeckID;
    public string Name;
    public string UserID;
    public List<DeckCard> Cards;
    public long CreationDateTicks;
    public long LastModifiedDateTicks;

    public Deck(string deckName)
    {
        DeckID = Guid.NewGuid().ToString();
        Name = deckName;
        UserID = "";
        Cards = new List<DeckCard>();
        CreationDateTicks = 0;
        LastModifiedDateTicks = 0;
    }

    public DateTime GetCreationDate()
    {
        return new DateTime(CreationDateTicks);
    }

    public void SetCreationDate(DateTime creationDate)
    {
        CreationDateTicks = creationDate.Ticks;
    }

    public DateTime GetLastModifiedDate()
    {
        return new DateTime(LastModifiedDateTicks);
    }

    public void SetLastModifiedDate(DateTime lastModifiedDate)
    {
        LastModifiedDateTicks = lastModifiedDate.Ticks;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref DeckID);
        serializer.SerializeValue(ref Name);
        serializer.SerializeValue(ref UserID);
        serializer.SerializeValue(ref CreationDateTicks);
        serializer.SerializeValue(ref LastModifiedDateTicks);

        int cardCount = Cards?.Count ?? 0;
        serializer.SerializeValue(ref cardCount);

        if (serializer.IsReader)
        {
            Cards = new List<DeckCard>(cardCount);
        }

        for (int i = 0; i < cardCount; i++)
        {
            if (serializer.IsReader)
            {
                Cards.Add(new DeckCard());
            }
            var card = Cards[i];
            card.NetworkSerialize(serializer);
            Cards[i] = card;
        }
    }
}