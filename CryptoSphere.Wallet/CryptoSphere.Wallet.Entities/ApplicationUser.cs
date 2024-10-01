﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Entities
{
    public class ApplicationUser : IdentityUser
    { 
        public string Country {  get; set; }
        public Wallet? Wallet { get; set; }
    }
}
