using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Getnet.Models
{
    public class DetailCardError
    {
        public string status { get; set; }
        public string error_code { get; set; }
        public string description { get; set; }
        public string description_detail { get; set; }
    }

    public class TokenCardResponseError
    {
        public int status_code { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public List<DetailCardError> details { get; set; }
    }

}
