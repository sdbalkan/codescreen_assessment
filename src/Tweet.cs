using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeScreen.Assessments.TweetsApi.src
{
    public class Tweet
    {
        //[JsonPropertyName("id")]
        public string Id { get; set; }

        //[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        //[JsonPropertyName("text")]
        public string Text { get; set; }

        //[JsonPropertyName("user")]
        public User User { get; set; }
    }
}
