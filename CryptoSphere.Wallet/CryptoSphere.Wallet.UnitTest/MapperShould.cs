using CryptoSphere.Wallet.Application.Common.Mappers;
using CryptoSphere.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.UnitTest
{
    public class MapperShould
    {
        [Fact]
        public void MapWalletToWalletDto()
        {
            //Arrange
            var wallet = new Entities.Wallet
            {
                BalanceUSD = 100.25m,
                UpdatedAt = DateTime.UtcNow,
                WalletStatus = Entities.Enums.WalletStatus.Active
            };
            
            //Act
            var walletDto = wallet.ToWalletDto();

            //Assert
            Assert.Equal(wallet.BalanceUSD, walletDto.BalanceUSD);
            Assert.Equal(wallet.UpdatedAt, walletDto.UpdatedAt);
            Assert.Equal(wallet.WalletStatus, walletDto.Status);
        }

        [Fact]
        public void MapCryptoCoinToCryptoCoinDto()
        {
            //Arrange
            var coin = new CryptoCoin
            {
                CoinSymbol = Entities.Enums.CryptoCoinSymbol.XRP,
                Quantity = 12.50m,
                ValueInUSD = 1200.3m,
                Wallet = new Entities.Wallet
                {
                    BalanceUSD = 1222.50m,
                    UpdatedAt = DateTime.UtcNow,
                }
            };
            //act
            var coinDto = coin.ToCryptoCoinDto();

            //Assert
            Assert.Equal(coin.CoinSymbol, coinDto.CoinSymbol);
            Assert.Equal(coin.Quantity, coinDto.Quantity);
            Assert.Equal(coin.ValueInUSD, coinDto.ValueInUSD);
            Assert.Equal(coin.Wallet.BalanceUSD, coinDto.Wallet.BalanceUSD);
            Assert.Equal(coin.Wallet.UpdatedAt, coinDto.Wallet.UpdatedAt);
        }
    }
}
