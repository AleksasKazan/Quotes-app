using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using QuotesApp.Models.Favqs.RequestModels;
using QuotesApp.Models.Favqs.ResponseModels;

namespace QuotesApp
{
    public class FavqsClient : IFavqsClient
    {
        private readonly HttpClient _httpClient;

        public FavqsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<QotdResponseModel> GetQotd()
        {
            const string url = "/api/qotd";
            return _httpClient.GetFromJsonAsync<QotdResponseModel>(url);
        }

        public Task<QuotesResponseModel> GetQuotes()
        {
            const string url = "/api/quotes";
            return _httpClient.GetFromJsonAsync<QuotesResponseModel>(url);
        }

        public Task<Quote> GetQuote(int quoteId)
        {
            string url = $"/api/quotes/{quoteId}";
            return _httpClient.GetFromJsonAsync<Quote>(url);
        }

        public async Task<string> AddQuote(string author, string quote, string userToken)
        {
            string url = $"/api/quotes";
            var post = new QotdResponseModel
            {
                Quote = new Quote
                {
                    Author = author,
                    Body = quote
                }
            };
            var postJson = JsonSerializer.Serialize(post);
            var request = new HttpRequestMessage

            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
                Content = new StringContent(postJson, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("User-Token", $"{userToken}");
            var response = await _httpClient.SendAsync(request);
            string statusCode = response.StatusCode.ToString();
            //return await response.Content.ReadFromJsonAsync<QuotesResponseModel>();
            return statusCode;
        }

        public async Task<string> FavQuote(int quoteId, string userToken)
        {
            string url = $"/api/quotes/{quoteId}/fav";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
            };
            request.Headers.Add("User-Token", $"{userToken}");
            var response = await _httpClient.SendAsync(request);
            string statusCode = response.StatusCode.ToString();
            //return await response.Content.ReadFromJsonAsync<QuotesResponseModel>();
            return statusCode;
        }

        public async Task<string> UnFavQuote(int quoteId, string userToken)
        {
            string url = $"/api/quotes/{quoteId}/unfav";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
            };
            request.Headers.Add("User-Token", $"{userToken}");
            var response = await _httpClient.SendAsync(request);
            string statusCode = response.StatusCode.ToString();
            //return await response.Content.ReadFromJsonAsync<QuotesResponseModel>();
            return statusCode;
        }

        public async Task<LoginResponseModel> GetUserToken(string userName, string password)
        {
            var url = "/api/session";
            var post = new LoginRequestModel
            {
                User = new User
                {
                    Login = userName,
                    Password = password
                }
            };
            var postJson = JsonSerializer.Serialize(post);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
                Content = new StringContent(postJson, Encoding.UTF8, "application/json")
            };
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<LoginResponseModel>();

        }

        public async Task<LoginResponseModel> CreateUser(string userName, string email, string password)
        {
            var url = "/api/users";
            var post = new LoginRequestModel
            {
                User = new User
                {
                    Login = userName,
                    Email = email,
                    Password = password
                }
            };
            var postJson = JsonSerializer.Serialize(post);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
                Content = new StringContent(postJson, Encoding.UTF8, "application/json")
            };
            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<LoginResponseModel>();
        }


        public async Task<string> LogOut(string userToken)
        {
            const string url = "/api/session";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_httpClient.BaseAddress, url),
            };
            request.Headers.Add("User-Token", $"{userToken}");
            var response = await _httpClient.SendAsync(request);
            string statusCode = response.StatusCode.ToString();
            return statusCode;
        }
    }
}
