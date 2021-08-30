using System;
using System.Text.Json.Serialization;

namespace QuotesApp.Models.Favqs.ResponseModels
{
    public class LoginResponseModel
    {
        [JsonPropertyName("User-Token")]
        public string UserToken { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{UserToken}\n{ErrorCode}{Message}";
        }
    }

}
