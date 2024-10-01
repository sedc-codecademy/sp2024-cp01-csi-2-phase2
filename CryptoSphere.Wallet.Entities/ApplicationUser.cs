using Microsoft.AspNetCore.Identity;

namespace CryptoSphere.Wallet.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Country { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
