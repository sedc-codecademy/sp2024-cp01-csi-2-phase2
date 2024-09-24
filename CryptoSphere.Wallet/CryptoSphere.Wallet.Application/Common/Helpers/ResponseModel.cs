using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.Helpers
{
    public class ResponseModel
    {
        public bool IsValid {  get; set; }
        public string ValidationMessage { get; set; }
    }
}
