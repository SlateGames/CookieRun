using Unity.Netcode;

public struct DeckCard : INetworkSerializable
{
    public string DeckID;
    public string CardID;
    public int Quantity;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref DeckID);
        serializer.SerializeValue(ref CardID);
        serializer.SerializeValue(ref Quantity);
    }
}