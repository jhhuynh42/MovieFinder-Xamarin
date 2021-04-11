using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MovieFinder.Model
{
    public class ListContent
    {
        [JsonProperty("Search")]
        public List<SearchList> Search { get; set; }

        [JsonProperty("totalResults")]
        public string totalResults { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }
    }
}
