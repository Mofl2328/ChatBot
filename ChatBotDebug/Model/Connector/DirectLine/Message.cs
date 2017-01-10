using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatBotDebug.Model.Connector.Schema
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("conversationId")]
        public string ConversationId { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("images")]
        public IList<string> Images { get; set; }

        [JsonProperty("attachments")]
        public IList<string> Attachments { get; set; }

        [JsonProperty("eTag")]
        public string ETag { get; set; }
    }
}