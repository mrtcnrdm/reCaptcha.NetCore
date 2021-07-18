using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace reCaptcha.NetCore.Models
{
    public class reCaptcha
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}