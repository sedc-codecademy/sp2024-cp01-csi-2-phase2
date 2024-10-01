namespace CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos
{
    public class WalletDto : BaseWalletDto
    {
        public int WalletId { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string WalletAddress { get; set; }
    }
}
