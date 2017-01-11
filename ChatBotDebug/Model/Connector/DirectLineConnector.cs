using ChatBotDebug.Model.Connector.Schema;
using ChatBotDebug.Model.Interfaces;
using DirectLineClient;
using Java.Lang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBotDebug.Model.Connector
{
    class DirectLineConnector : IConnector
    {
        private ObservableCollection<ChatBotDebug.Util.Message> receiver;
        string conversationId;
        string conversationToken;
        string secret = "a_Bvj4GE-2I.cwA.nOY.b45d41an_S342sIyc-QOxxA9eXrHH9jY9iiwhdLgrfE";
        string watermark;
        private const string host = "https://directline.botframework.com";
        string user = "Moritz";
        HttpClient httpClient;

        public DirectLineConnector(ObservableCollection<ChatBotDebug.Util.Message> receiver)
        {

            httpClient = new HttpClient();
            this.receiver = receiver;

            watermark = "";

            startConversation();
          
        }


        async private Task getMessages()
        {
          
            string url;
            if (watermark == "")
                 url = $"{host}/api/conversations/{conversationId}/messages";
            else
                url = $"{host}/api/conversations/{conversationId}/messages?watermark={watermark}";


            {
//                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BotConnector", secret);
//                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetStringAsync(url);

                var messages = JsonConvert.DeserializeObject<ConversationMessages>(response);

                this.watermark = messages.Watermark;

                foreach (var message in messages.Messages)
                {
                    Thread.Sleep(100);
                    if (message.From != user)
                    {
                        addToReceiver(message.From + watermark, message.Text);
                    } else
                    {

                    }
                }
            }
        }

        private void addToReceiver(string from, string text)
        {

            receiver.Add(new ChatBotDebug.Util.Message(from, text));


        }


        public async Task sendMessage(string text, string from, string to)
        {

            if (text == "get")
            {
                await getMessages();
            }
            else
            {
                string url = $"{host}/api/conversations/{conversationId}/messages";

                addToReceiver(from, text);
 
                var message = new 
                {
                    From = from,
                    Text = text
                };

                HttpContent content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

                {
//                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BotConnector", secret);
//                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = await httpClient.PostAsync(url, content);

                    if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        //response.EnsureSuccessStatusCode();
                    }
                }
            }
            await getMessages();
        }


        public async void startConversation()
        {
            string conversationsAPI = $"{host}/api/conversations";

            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BotConnector", secret);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.PostAsync(conversationsAPI, null);

                response.EnsureSuccessStatusCode();

                var greeting = JsonConvert.DeserializeObject<StartConversationResponse>(await response.Content.ReadAsStringAsync());
                conversationId = greeting.ConversationId;
                conversationToken = greeting.Token;
            }



        }

    }
}
