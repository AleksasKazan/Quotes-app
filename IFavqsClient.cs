using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuotesApp.Models.Favqs.RequestModels;
using QuotesApp.Models.Favqs.ResponseModels;

namespace QuotesApp
{
    public interface IFavqsClient
    {
        Task<QotdResponseModel> GetQotd();

        Task<QuotesResponseModel> GetQuotes();

        Task<Quote> GetQuote(int quoteId);

        Task<string> AddQuote(string author, string quote, string userToken);

        Task<string> FavQuote(int quoteId, string userToken);

        Task<string> UnFavQuote(int quoteId, string userToken);

        Task<LoginResponseModel> GetUserToken(string userName, string password);

        Task<LoginResponseModel> CreateUser(string userName, string email, string password);

        Task<string> LogOut(string userToken);
    }
}
