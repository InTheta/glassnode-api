using Newtonsoft.Json;

namespace Glassnode.Api.Responses
{
    public class HashRibbon
    {
        [JsonProperty("buy")]
        public long Buy { get; set; }

        [JsonProperty("capitulation")]
        public long Capitulation { get; set; }

        [JsonProperty("crossed")]
        public long Crossed { get; set; }

        [JsonProperty("ma30")]
        public double Ma30 { get; set; }

        [JsonProperty("ma60")]
        public double Ma60 { get; set; }
    }
}