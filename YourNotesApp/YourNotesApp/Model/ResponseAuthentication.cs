using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourNotesApp.Model
{
    public class ResponseAuthentication
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        
        [JsonProperty("localId")]
        public string LocalId { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        
        [JsonProperty("idToken")]
        public string IdToken { get; set; }
        
        [JsonProperty("registered")]
        public string Registered { get; set; }

        [JsonProperty("refreshToken")]
        public bool RefreshToken { get; set; }

        [JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }
    }
}
