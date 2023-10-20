using Newtonsoft.Json;

namespace SSH_Configurer_UI.Model.DTOs.Async
{
    public class AsyncResponse
    {
        public class Message
        {
            public string request_uuid { get; set; }
            public int device { get; set; }
            public string status { get; set; }
            public List<string> warnings { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string result_std { get; set; } = "";
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string result_err { get; set; } = "";

        }

        public string type { get; set; }
        public Message message { get; set; }
    }
}
