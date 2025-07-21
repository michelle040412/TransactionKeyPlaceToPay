using System.ComponentModel.DataAnnotations;

namespace TransactionKeyPlaceToPay.dtos
{
    public class TransactionKeyRequestDto
    {
        [Required]
        public required string SecretKey { get; set; }
    }
}
