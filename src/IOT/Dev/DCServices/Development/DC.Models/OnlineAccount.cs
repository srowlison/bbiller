using System;

namespace DC.Common.Models
{
    public class OnlineAccount
    {
        public bool Success { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmToken { get; set; }
    }
}
