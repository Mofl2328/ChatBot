using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChatBotDebug.Model.Connector.Schema
{
    public class ConversationMessages
    {
        [JsonProperty("messages")]
        public IList<Message> Messages { get; set; }

        [JsonProperty("watermark")]
        public string Watermark { get; set; }
    }
}