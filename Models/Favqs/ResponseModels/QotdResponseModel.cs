using System;
using System.Text.Json.Serialization;

namespace QuotesApp.Models.Favqs.ResponseModels
{
    public class QotdResponseModel
    {
        [JsonPropertyName("qotd_date")]
        public DateTime QotdDate { get; set; }

        [JsonPropertyName("quote")]
        public Quote Quote { get; set; }

        public override string ToString()
        {
            return $"{Quote.Id}{Quote.Author}{Quote.Body}";
        }
    }
}
