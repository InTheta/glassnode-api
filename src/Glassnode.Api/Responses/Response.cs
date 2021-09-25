using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Glassnode.Api.Responses
{
    public class Response
    {
        [JsonProperty("t"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Time { get; set; }

        [JsonProperty("v")]
        public double? Value { get; set; }
        
        [JsonProperty("o")]
        public Dictionary<string, double> Data { get; set; }
    }
}