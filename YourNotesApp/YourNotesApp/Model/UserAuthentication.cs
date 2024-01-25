using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace YourNotesApp.Model
{
    public class UserAuthentication
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; }
    }
}
