using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Getnet.Models
{
    public class TokenCardRequest
    {
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
    }
}
