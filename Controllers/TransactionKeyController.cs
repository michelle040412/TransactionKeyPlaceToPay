using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using TransactionKeyPlaceToPay.dtos;
using TransactionKeyPlaceToPay.Dtos;

namespace TransactionKeyPlaceToPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionKeyController : ControllerBase
    {
        [HttpGet(Name = "GetTransactionKey")]
        public TransactionKeyResponseDto Get([Required]string secretKey, [Required] double amount)
        {
            DateTime date = DateTime.UtcNow; // Expira en 5 minutos
            string seed = date.ToString("o");// ISO 8601
            string rawNonce = new Random().Next(0, 1000000).ToString();

            // Crear hash SHA-256 de (nonce + seed + secretKey)
            string combined = rawNonce + seed + secretKey;
            byte[] hash;

            using (var sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
            }

            string tranKey = Convert.ToBase64String(hash);
            string nonce = Convert.ToBase64String(Encoding.UTF8.GetBytes(rawNonce));
            string reference = $"Ord:{rawNonce}/{DateTime.UtcNow:yyyy/MM/dd}";
            return new TransactionKeyResponseDto
            {
                TransactionKey = tranKey,
                Nonce = nonce,
                Seed = seed,
                Amount = amount,
                Reference = reference,
                Expiration = date.AddMinutes(10).ToString("o") // Expira en 10 minutos
            };
        }
    }
}
