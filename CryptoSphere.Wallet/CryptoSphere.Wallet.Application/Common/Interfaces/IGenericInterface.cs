using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.Interfaces
{
    internal interface IGenericInterface<T>
    {
        Task Delete(Guid id);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
    }
}
