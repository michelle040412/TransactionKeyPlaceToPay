namespace TransactionKeyPlaceToPay.Dtos
{
    public class TransactionKeyResponseDto
    {
        public required string TransactionKey { get; set; }
        public required string Nonce { get; set; }
        public required string Seed { get; set; }
        public required string Expiration { get; set; }
        public required string Reference { get; set; }
        public required double Amount { get; set; }
    }
}
