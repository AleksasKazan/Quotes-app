using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using QuotesApp.Models.Favqs.RequestModels;

namespace QuotesApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();
            var jsonFavqsClient = serviceProvider.GetService<IFavqsClient>();
            Console.WriteLine("Enter username:\nEnter password:");
            var token = await jsonFavqsClient.GetUserToken(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(token);
            var tokenString = token.UserToken;
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("\nCreate new User: 0");
                Console.WriteLine("Show all quotes: 1");
                Console.WriteLine("Get quote by Id press: 2");
                Console.WriteLine("Fav quote press: 3");
                Console.WriteLine("UnFav quote press: 4");
                Console.WriteLine("Quote of the day press: 5");
                Console.WriteLine("Add quote press: 6");
                Console.WriteLine("End session press: ESC");
                cki = Console.ReadKey();
                Console.Clear();
                switch (cki.Key)
                {
                    case ConsoleKey.D0:
                        var newUser = await jsonFavqsClient.CreateUser(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                        Console.WriteLine(newUser);
                        break;
                    case ConsoleKey.D1:
                        var quotes = await jsonFavqsClient.GetQuotes();
                        foreach (var item in quotes.Quotes)
                        {
                            Console.WriteLine($"{item.Id} {item.Author} {item.Body}");
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Enter quote Id: ");
                        var quote = await jsonFavqsClient.GetQuote(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine(quote);
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Enter Fav quote Id: ");
                        var favQuote = await jsonFavqsClient.FavQuote(Convert.ToInt32(Console.ReadLine()), tokenString);
                        Console.WriteLine(favQuote);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Enter UnFav quote Id: ");
                        var unfavQuote = await jsonFavqsClient.UnFavQuote(Convert.ToInt32(Console.ReadLine()), tokenString);
                        Console.WriteLine(unfavQuote);
                        break;
                    case ConsoleKey.D5:
                        var qotd = await jsonFavqsClient.GetQotd();
                        Console.WriteLine(qotd);
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("To Add quote enter Author name: \nQuote text: ");
                        var newQuote = await jsonFavqsClient.AddQuote(Console.ReadLine(), Console.ReadLine(), tokenString);
                        Console.WriteLine(newQuote);
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            var logOut = await jsonFavqsClient.LogOut(tokenString);
            Console.WriteLine($"{logOut} Good by");
        }
    }
}
