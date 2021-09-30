using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Getnet.Models
{
    public class TokenCardResponse
    {
        [JsonProperty("number_token")]
        public string NumberToken { get; set; }
    }
}
