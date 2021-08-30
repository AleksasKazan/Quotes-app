using System;
using System.Text.Json.Serialization;

namespace QuotesApp.Models.Favqs.RequestModels
{
    public class LoginRequestModel
    {
        [JsonPropertyName("user")]
        public User User { get; set; }      

        public override string ToString()
        {
            return $"{User.Login} {User.Password}";
        }
    }

    public class User
    {
        [JsonPropertyName("login")]
        //public string Login = "AlexK";
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        //public string Password = "testtest";
        public string Password { get; set; }
    }
}
