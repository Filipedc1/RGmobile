using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.Models
{
    public class AuthenticatedUser
    {
        public string AccessToken       { get; set; }
        public string AccessTokenId     { get; set; }
        public bool IsAuthenticated     { get; set; }
        public DateTime Expires         { get; set; }
        public string Username          { get; set; }
        public string Role              { get; set; }
    }
}
