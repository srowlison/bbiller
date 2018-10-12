using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class Keys
    {
        public String PublicKey { get; set; }
        public String PrivateKey { get; set; }
        public Byte[] Password { get; set; }
    }
}