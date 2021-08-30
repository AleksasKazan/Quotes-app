using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuotesApp.Models.Favqs.ResponseModels
{
    public class QuotesResponseModel
    {

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("last_page")]
        public bool LastPage { get; set; }

        [JsonPropertyName("quotes")]
        public List <Quotes> Quotes { get; set; }

        public override string ToString()
        {
            return $"{Quotes}";
        }
    }

    public class Quotes
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dialogue")]
        public bool Dialogue { get; set; }

        [JsonPropertyName("private")]
        public bool Private { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("favorites_count")]
        public int FavoritesCount { get; set; }

        [JsonPropertyName("upvotes_count")]
        public int UpvotesCount { get; set; }

        [JsonPropertyName("downvotes_count")]
        public int DownvotesCount { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("author_permalink")]
        public string AuthorPermalink { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        public override string ToString()
        {
            return $"{Id}{Author}\n{Body}";
        }
    }
}

